namespace Flights.Application.Dtos
{
    public class BookedFlightReturnDto
    {
        public string CustomerName { get; set; }
        public string Seat { get; set; }
        public int BookedFlightId { get; set; }
        public string FlightCode { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalDate { get; set; }
        public decimal Price { get; set; }
    }
}