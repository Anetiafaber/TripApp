using Anetia_TripApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Anetia_TripApp.Controllers
{
    public class TripController : Controller
    {
        private TripDbContext _ctx { get; set; }
        public TripController(TripDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add(string page)
        {
            if (page == "Page2")
            {
                // Load Accommodation name to fill the details
                var accommodationId = TempData["AccommodationId"] as int?;
                var accommodation = _ctx.Accommodations.FirstOrDefault(a => a.AccommodationId == accommodationId);

                var model = new Page2ViewModel
                {
                    AccommodationName = accommodation?.Name
                };
                TempData.Keep();
                return View("Page2", model);
            }
            else if (page == "Page3")
            {
                // Load destination name and available activities
                var destinationId = TempData["DestinationId"] as int?;

                var destination = _ctx.Destinations.FirstOrDefault(d => d.DestinationId == destinationId);

                TempData["DestinationName"] = destination?.Name;

                var availableActivities = _ctx.Activities.Select(a => new SelectListItem
                {
                    Value = a.ActivityId.ToString(),
                    Text = a.Name
                }).ToList();

                var model = new Page3ViewModel
                {
                    Destination = destination?.Name,
                    AvailableActivities = availableActivities
                };
                TempData.Keep();
                return View("Page3", model);
            }
            else
            {
                // Load the destinations and accommodations options
                TempData.Clear();
                return View("Page1", new Page1ViewModel
                {
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today,
                    Destinations = new SelectList(_ctx.Destinations, "DestinationId", "Name"),
                    Accommodations = new SelectList(_ctx.Accommodations, "AccommodationId", "Name")
                });
            }

        }
        [HttpPost]
        public IActionResult Page1(Page1ViewModel model)
        {
            // Store the inputed values in tempdata and move to next page
            if (ModelState.IsValid)
            {
                TempData["DestinationId"] = model.DestinationId;
                TempData["StartDate"] = model.StartDate;
                TempData["EndDate"] = model.EndDate;
                TempData["AccommodationId"] = model.AccommodationId;

                if(model.AccommodationId != null)
                {
                    return RedirectToAction("Add", new { page = "Page2" });
                }
                else
                {
                    return RedirectToAction("Add", new { page = "Page3" });
                }
            }

            model.Destinations = new SelectList(_ctx.Destinations.ToList(), "DestinationId", "Name", model.DestinationId);
            model.Accommodations = new SelectList(_ctx.Accommodations.ToList(), "AccommodationId", "Name", model.AccommodationId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Page2(Page2ViewModel model)
        {
            // Store the inputed values in tempdata
            if (ModelState.IsValid)
            {
                TempData["AccommodationPhone"] = model.AccommodationPhone;
                TempData["AccommodationEmail"] = model.AccommodationEmail;
                return RedirectToAction("Add", new { page = "Page3" });
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Page3(Page3ViewModel model)
        {
            // Retrieve values from tempdata to insert in db
            if (ModelState.IsValid)
            {
                var trip = new Trip
                {
                    DestinationId = int.Parse(TempData["DestinationId"].ToString()),
                    StartDate = DateTime.Parse(TempData["StartDate"].ToString()),
                    EndDate = DateTime.Parse(TempData["EndDate"].ToString()),
                    AccommodationId = TempData["AccommodationId"] != null ? (int?)TempData["AccommodationId"] : null,
                    Activities = new List<Activity>()
                };

                TempData.Keep();

                if (model.SelectedActivityIds != null)
                {
                    foreach (var activityId in model.SelectedActivityIds)
                    {
                        var activity = _ctx.Activities.FirstOrDefault(a => a.ActivityId == activityId);
                        if (activity != null)
                        {
                            trip.Activities.Add(activity);
                        }
                    }
                }

                _ctx.Trips.Add(trip);
                _ctx.SaveChanges();

                if (TempData["AccommodationId"] != null)
                {
                    int accommodationId = int.Parse(TempData["AccommodationId"].ToString());
                    var accommodation = _ctx.Accommodations.FirstOrDefault(a => a.AccommodationId == accommodationId);

                    if (accommodation != null)
                    {
                        if (TempData["AccommodationPhone"] != null)
                            accommodation.PhoneNumber = TempData["AccommodationPhone"].ToString();

                        if (TempData["AccommodationEmail"] != null)
                            accommodation.Email = TempData["AccommodationEmail"].ToString();

                        _ctx.SaveChanges();
                    }
                }

                TempData.Keep();

                TempData["Message"] = "Trip to " + TempData["DestinationName"] + " added!";
                return RedirectToAction("Index", "Home");
            }

            var availableActivities = _ctx.Activities.Select(a => new SelectListItem
            {
                Value = a.ActivityId.ToString(),
                Text = a.Name
            }).ToList();

            model.Destination = TempData["DestinationName"].ToString();

            model.AvailableActivities = availableActivities;

            TempData.Keep();

            return View(model);
        }
        
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
