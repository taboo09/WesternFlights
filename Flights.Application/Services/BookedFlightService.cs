using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flights.Application.Interfaces;
using Flights.Domain.Core;
using Flights.Domain.Models;
using Flights.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Flights.Application.Services
{
    public class BookedFlightService : IBookedFlightService
    {
        private readonly IAppRepository<FlightDbContext> _repo;
        public BookedFlightService(IAppRepository<FlightDbContext> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<string>> GetUnavailableSeats(int flightId)
        {
            var seats = await _repo.GetAll<BookedFlight>()
                .Where(x => x.FlightId == flightId)
                .Select(x => x.Seat)
                .ToListAsync();

            return seats;
        }

        public void AddBookedFlight(BookedFlight flight)
        {
            _repo.Add<BookedFlight>(flight);
        }

        public async Task<IEnumerable<BookedFlight>> GetBookedFlights(int page, int size)
        {
            var flights = await _repo.GetAll<BookedFlight>()
                .Include(x => x.Flight)
                .ThenInclude(x => x.DepartureAirport)
                .OrderBy(x => x.BookedFlightId)
                .Skip(page * size)
                .Take(size)
                .ToListAsync();

            return flights;
        }

        public async Task<bool> CheckSeat(int flightId, string seat) 
            => (await _repo.FindEntity<BookedFlight>(x => x.FlightId == flightId && x.Seat == seat) == null);

        public async Task SaveChanges() => await _repo.SaveAll();
    }
}