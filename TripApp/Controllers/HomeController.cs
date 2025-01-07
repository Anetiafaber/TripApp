using Anetia_TripApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Anetia_TripApp.Controllers
{
    public class HomeController : Controller
    {
        private TripDbContext _ctx { get; set; }
        public HomeController(TripDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            // Banner to display message if any
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            // Load the trips data
            var trips = _ctx.Trips
                .Include(t => t.Destination)
                .Include(t => t.Accommodation)
                .Include(t => t.Activities)
                .ToList();

            return View(trips);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Delete a trip
            var trip = _ctx.Trips.FirstOrDefault(t => t.TripId == id);
            if (trip != null)
            {
                _ctx.Trips.Remove(trip);
                _ctx.SaveChanges();
                TempData["Message"] = "Trip deleted successfully!";
            }
            else
            {
                TempData["Message"] = "Trip not found!";
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
