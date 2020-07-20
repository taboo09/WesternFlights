using AutoMapper;
using Flights.Application.Dtos;
using Flights.Domain.Models;

namespace Flights.API.MappingProfile
{
    public class MappingAirportProfile : Profile
    {
        public MappingAirportProfile()
        {
            // entity to dto
            CreateMap<Airport, AirportDto>()
                .ForMember(x => x.NrDeptFlights, opt => opt.MapFrom(y => y.DepartureFlights.Count))
                .ForMember(x => x.NrArrFlights, opt => opt.MapFrom(y => y.ArrivalFlights.Count));
        }
    }
}