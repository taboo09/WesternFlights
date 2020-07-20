using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.Domain.Models;

namespace Flights.Application.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> AllAirports();
    }
}