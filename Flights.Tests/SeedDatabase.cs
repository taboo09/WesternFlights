using System.Collections.Generic;
using System.Linq;
using Flights.Domain.Models;
using Flights.Infrastructure.Context;

namespace Flights.Tests
{
    public class SeedDatabase
    {
        public static void Initialize(FlightDbContext context)
        {
            SeedAirports(context);
        }

        private static void SeedAirports(FlightDbContext context)
        {
            var airports = new List<Airport>
            {
                new Airport 
                {
                    AirportId = 101,
                    AirportCode = "TEST",
                    AirportCity = "London"
                },
                new Airport 
                {
                    AirportId = 102,
                    AirportCode = "FAKE",
                    AirportCity = "Madrid"
                }
            };

            context.Airports.AddRange(airports);

            context.SaveChanges();
        }
    }
}