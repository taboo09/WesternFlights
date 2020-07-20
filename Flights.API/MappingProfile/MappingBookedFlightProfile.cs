using AutoMapper;
using Flights.Application.Dtos;
using Flights.Domain.Models;

namespace Flights.API.MappingProfile
{
    public class MappingBookedFlightProfile : Profile
    {
        public MappingBookedFlightProfile()
        {
            // dto to entity
            CreateMap<NewBookedFlightDto, BookedFlight>();

            // entity to dto
            CreateMap<BookedFlight, BookedFlightReturnDto>()
                .ForMember(x => x.FlightCode, opt => opt.MapFrom(y => y.Flight.FlightCode))
                .ForMember(x => x.Price, opt => opt.MapFrom(y => y.Flight.Price))
                .ForMember(x => x.DepartureDate, opt => opt.MapFrom(y => y.Flight.DepartureDateTime))
                .ForMember(x => x.ArrivalDate, opt => opt.MapFrom(y => y.Flight.ArrivalDateTime))
                .ForMember(x => x.DepartureAirport, opt => opt.MapFrom(y => 
                    $"{y.Flight.DepartureAirport.AirportCode}, {y.Flight.DepartureAirport.AirportCity}"))
                .ForMember(x => x.ArrivalAirport, opt => opt.MapFrom(y => 
                    $"{y.Flight.ArrivalAirport.AirportCode}, {y.Flight.ArrivalAirport.AirportCity}"));
        }
    }
}