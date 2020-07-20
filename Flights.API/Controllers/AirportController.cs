using AutoMapper;
using Flights.Application.Dtos;
using Flights.Application.Interfaces;
using Flights.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flights.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;
        public AirportController(IAirportService airportService, IMapper mapper)
        {
            _airportService = airportService ?? throw new ArgumentNullException(nameof(airportService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET api/airport
        [HttpGet]
        public async Task<IActionResult> Aiports()
        {
            var airports = await _airportService.AllAirports();

            return Ok(_mapper.Map<List<AirportDto>>(airports));
        }
    }
}