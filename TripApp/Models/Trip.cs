using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Required(ErrorMessage = "Please select a destination!")]
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public int? AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }

        [Required(ErrorMessage = "Please enter the start date!")]
        [FutureDateValidation]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the end date!")]
        [FutureDateValidation]
        [EndDateValidation]
        public DateTime EndDate { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
