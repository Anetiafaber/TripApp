using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class Page1ViewModel
    {
        [Required(ErrorMessage = "Please enter the destination!")]
        public int? DestinationId { get; set; }
        public SelectList? Destinations { get; set; }
        public int? AccommodationId { get; set; }
        public SelectList? Accommodations { get; set; }

        [Required(ErrorMessage = "Please enter the start date!")]
        [FutureDateValidation]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the end date!")]
        [FutureDateValidation]
        [EndDateValidation]
        public DateTime EndDate { get; set; }
    }
}
