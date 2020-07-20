using System;

namespace Flights.Application.Dtos
{
    public class NewFlightDto
    {
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public decimal Price { get; set; }
        public int MaxNumberSeats { get; set; }
    }
}