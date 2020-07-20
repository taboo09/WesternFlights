using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flights.Domain.Models
{
    public class BookedFlight
    {
        public int BookedFlightId { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(3, MinimumLength = 2)]
        public string Seat { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}