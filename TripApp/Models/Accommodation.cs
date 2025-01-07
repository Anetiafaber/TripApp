using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }
        [Required(ErrorMessage = "Please enter the accommodation name!")]
        public string Name { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format 123-456-7890.")]
        public string? PhoneNumber { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
