using System.Collections.Generic;
using Flights.Application.Dtos;

namespace Flights.API.Helper
{
    public class FlightsReturn
    {
        public List<FlightReturnDto> DepartureFlights { get; set; }
        public List<FlightReturnDto> ReturnFlights { get; set; }
    }
}