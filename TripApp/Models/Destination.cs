using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }

        [Required(ErrorMessage = "Please enter the destination!")]
        public string Name { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
