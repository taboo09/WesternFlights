using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flights.Domain.Models
{
    public class Flight
    {
        public Flight()
        {
            // OutboundFlights = new HashSet<BookedFlight>();
            // ReturnFlights = new HashSet<BookedFlight>();
            BookedFlights = new HashSet<BookedFlight>();
        }

        public int FlightId { get; set; }

        [StringLength(7, MinimumLength = 7)]
        public string FlightCode { get; set; }

        [ForeignKey("DepartureAirportId")]
        public virtual Airport DepartureAirport { get; set; }

        [ForeignKey("ArrivalAirportId")]
        public virtual Airport ArrivalAirport { get; set; }

        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }

        [Range(0, 9999.99)]
        [Column(TypeName = "decimal(16,2)")]
        public decimal Price { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

        [Range(0, 30)]
        public int MaxNumberSeats { get; set; }
        public virtual ICollection<BookedFlight> BookedFlights { get; set; }
    }
}