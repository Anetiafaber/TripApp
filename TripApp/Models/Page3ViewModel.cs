using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class Page3ViewModel
    {
        public string? Destination { get; set; }
        public IEnumerable<SelectListItem>? AvailableActivities { get; set; }  // Changed to IEnumerable<SelectListItem>
        public List<int>? SelectedActivityIds { get; set; }
    }
}
