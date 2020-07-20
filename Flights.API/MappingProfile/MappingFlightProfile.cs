using AutoMapper;
using Flights.Application.Dtos;
using Flights.Domain.Models;

namespace Flights.API.MappingProfile
{
    public class MappingFlightProfile : Profile
    {
        public MappingFlightProfile()
        {
            // entity to dto
            CreateMap<Flight, FlightReturnDto>()
                .ForMember(x => x.DepartureAirportName, opt => opt.MapFrom(y => $"{y.DepartureAirport.AirportCode}, {y.DepartureAirport.AirportCity}"))
                .ForMember(x => x.ArrivalAirportName, opt => opt.MapFrom(y => $"{y.ArrivalAirport.AirportCode}, {y.ArrivalAirport.AirportCity}"))
                .ForMember(x => x.AvailableSeats, opt => opt.MapFrom(y => (y.MaxNumberSeats * 3) - y.BookedFlights.Count));
        }
    }
}