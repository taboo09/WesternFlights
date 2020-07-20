using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.Application.Dtos;
using Flights.Domain.Models;

namespace Flights.Application.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> SearchForFlights(int depAirportId, int arrAirportId, DateTime flightDate);
        void NewFlight(Flight flight);
        Task SaveChanges();
    }
}