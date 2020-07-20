using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Flights.API.Helper;
using Flights.Application.Dtos;
using Flights.Application.Interfaces;
using Flights.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flights.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        public FlightController(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET api/flight
        [HttpGet]
        public async Task<IActionResult> SearchForFlights([FromQuery] FlightSearch flightSearch)
        {
            var departureFlights = await _flightService.SearchForFlights(flightSearch.DepartureAirportId, flightSearch.ArrivalAirportId, flightSearch.DepartureDate);

            IEnumerable<Flight> returnFlights = null;

            if (flightSearch.ReturnDate != null)
            {
                returnFlights = await _flightService.SearchForFlights(flightSearch.ArrivalAirportId, flightSearch.DepartureAirportId, (DateTime)flightSearch.ReturnDate);
            }

            var flightsToReturn = new FlightsReturn()
            {
                DepartureFlights = _mapper.Map<List<FlightReturnDto>>(departureFlights),
                ReturnFlights = returnFlights != null ? _mapper.Map<List<FlightReturnDto>>(returnFlights) : null
            };

            return Ok(flightsToReturn);
        }

    }
}