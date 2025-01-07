using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class Page2ViewModel
    {
        public string? AccommodationName { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format 123-456-7890.")]
        public string? AccommodationPhone { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format.")]
        public string? AccommodationEmail { get; set; }
    }
}
