namespace Flights.Application.Dtos
{
    public class NewBookedFlightDto
    {
        public string CustomerName { get; set; }
        public string Seat { get; set; }
        public int FlightId { get; set; }
    }
}