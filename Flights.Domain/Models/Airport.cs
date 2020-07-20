using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flights.Domain.Models
{
    public class Airport
    {
        public Airport()
        {
            DepartureFlights = new HashSet<Flight>();
            ArrivalFlights = new HashSet<Flight>();
        }
        
        public int AirportId { get; set; }

        [StringLength(3, MinimumLength = 3)]
        public string AirportCode { get; set; }

        [StringLength(50)]
        public string AirportCity { get; set; }

        [InverseProperty(nameof(Flight.DepartureAirport))]
        public virtual ICollection<Flight> DepartureFlights { get; set; }

        [InverseProperty(nameof(Flight.ArrivalAirport))]
        public virtual ICollection<Flight> ArrivalFlights { get; set; }
    }
}