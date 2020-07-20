using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.Domain.Models;

namespace Flights.Application.Interfaces
{
    public interface IBookedFlightService
    {
        Task<IEnumerable<string>> GetUnavailableSeats(int flightId);
        void AddBookedFlight(BookedFlight flight);
        Task<bool> CheckSeat(int flightId, string seat);
        Task<IEnumerable<BookedFlight>> GetBookedFlights(int page, int size);
        Task SaveChanges();
    }
}