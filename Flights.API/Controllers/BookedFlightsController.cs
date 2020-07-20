using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Flights.Application.Dtos;
using Flights.Application.Interfaces;
using Flights.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flights.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookedFlightsController : ControllerBase
    {
        private readonly IBookedFlightService _flightService;
        private readonly IMapper _mapper;
        private const int FLIGHTS_COUNT = 5;

        public BookedFlightsController(IBookedFlightService flightService, IMapper mapper)
        {
            _flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET api/bookedflights
        [HttpGet("seats/{flightId}")]
        public async Task<IActionResult> SelectedSeats(int flightId)
        {
            var seats = await _flightService.GetUnavailableSeats(flightId);

            return Ok(seats);
        }

        // POST api/bookedflights
        [HttpPost]
        public async Task<IActionResult> NewBookedFlights(List<NewBookedFlightDto> flights)
        {
            foreach (var flight in flights)
            {
                if (!await _flightService.CheckSeat(flight.FlightId, flight.Seat)) 
                    return BadRequest($"Seat {flight.Seat} has been booked by somebody else. Please book yor flight again.");

                _flightService.AddBookedFlight(_mapper.Map<BookedFlight>(flight));
            }

            try
            {
                await _flightService.SaveChanges();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
            
            return Ok( new { message = "Your flight has been booked" });
        }

        // POST api/bookedflights
        [HttpGet]
        public async Task<IActionResult> AllBookedFlights([FromQuery] int page)
        {
            var flights = await _flightService.GetBookedFlights(page, FLIGHTS_COUNT);

            return Ok(_mapper.Map<List<BookedFlightReturnDto>>(flights));
        }

    }
}