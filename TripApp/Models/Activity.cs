using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        [Required(ErrorMessage = "Please enter the activity!")]
        public string Name { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
