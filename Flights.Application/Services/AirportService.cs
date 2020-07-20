using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.Application.Interfaces;
using Flights.Domain.Core;
using Flights.Domain.Models;
using Flights.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Flights.Application.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAppRepository<FlightDbContext> _repo;
        public AirportService(IAppRepository<FlightDbContext> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<Airport>> AllAirports()
        {
            var airports = await _repo.GetAll<Airport>()
                .Include(x => x.DepartureFlights)
                .ToListAsync();

            return airports;
        }
    }
}