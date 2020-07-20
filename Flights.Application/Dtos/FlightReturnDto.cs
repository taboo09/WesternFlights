using System;

namespace Flights.Application.Dtos
{
    public class FlightReturnDto
    {
        public int FlightId { get; set; }
        public string FlightCode { get; set; }
        public string DepartureAirportName { get; set; }
        public string ArrivalAirportName { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public decimal Price { get; set; }
        public int MaxNumberSeats { get; set; }
        public int AvailableSeats { get; set; }
    }
}