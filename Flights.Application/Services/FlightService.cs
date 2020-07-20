using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flights.Application.Dtos;
using Flights.Application.Interfaces;
using Flights.Domain.Core;
using Flights.Domain.Models;
using Flights.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Flights.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IAppRepository<FlightDbContext> _repo;
        public FlightService(IAppRepository<FlightDbContext> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public void NewFlight(Flight flight) => _repo.Add<Flight>(flight);

        public async Task<IEnumerable<Flight>> SearchForFlights(int depAirportId, int arrAirportId, DateTime flightDate)
        {
            var flights = await _repo.GetAll<Flight>()
                .Include(x => x.DepartureAirport)
                .Include(x => x.ArrivalAirport)
                .Include(x => x.BookedFlights)
                .Where(x => x.DepartureAirportId == depAirportId 
                    && x.ArrivalAirportId == arrAirportId
                    && x.DepartureDateTime.Date == flightDate.Date)
                .ToListAsync();

            return flights;
        }

        public async Task SaveChanges() => await _repo.SaveAll();
    }
}


