using Flights.Application.Interfaces;
using Flights.Application.Services;
using Flights.Domain.Core;
using Flights.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Flights.Application.Container
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // repositories
            services.AddScoped(typeof(IAppRepository<>), typeof(AppRepository<>));

            // services
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IBookedFlightService, BookedFlightService>();
        }
    }
}