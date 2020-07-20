namespace Flights.Application.Dtos
{
    public class AirportDto
    {
        public int AirportId { get; set; }
        public string AirportCode { get; set; }
        public string AirportCity { get; set; }
        public int NrDeptFlights { get; set; }
        public int NrArrFlights { get; set; }
    }
}