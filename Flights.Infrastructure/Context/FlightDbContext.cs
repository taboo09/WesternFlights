using System;
using System.Linq;
using Flights.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.Context
{
    public class FlightDbContext : DbContext
    {
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<BookedFlight> BookedFlights { get; set; }

        public FlightDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>().HasData(
                new Airport() { AirportId = 1, AirportCode = "LHR", AirportCity = "London" }, //1
                new Airport() { AirportId = 2, AirportCode = "CDG", AirportCity = "Paris" }, //2
                new Airport() { AirportId = 3, AirportCode = "TXL", AirportCity = "Berlin" }, //3
                new Airport() { AirportId = 4, AirportCode = "BCN", AirportCity = "Barcelona" }, //4
                new Airport() { AirportId = 5, AirportCode = "GLA", AirportCity = "Glasgow" } //5
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight() { FlightId = 1, FlightCode = "000XT01", DepartureAirportId = 1, ArrivalAirportId = 5, Price = 80.00M, DepartureDateTime = new DateTime(2020, 07, 20, 10, 30, 00), ArrivalDateTime = new DateTime(2020, 07, 20, 11, 50, 00), MaxNumberSeats = 15 },
                new Flight() { FlightId = 2, FlightCode = "000XT02", DepartureAirportId = 1, ArrivalAirportId = 5, Price = 50.00M, DepartureDateTime = new DateTime(2020, 07, 20, 13, 00, 00), ArrivalDateTime = new DateTime(2020, 07, 20, 14, 00, 00), MaxNumberSeats = 20 },
                new Flight() { FlightId = 3, FlightCode = "000XR01", DepartureAirportId = 1, ArrivalAirportId = 3, Price = 240.00M, DepartureDateTime = new DateTime(2020, 07, 21, 08, 15, 00), ArrivalDateTime = new DateTime(2020, 07, 21, 10, 30, 00), MaxNumberSeats = 15 },
                new Flight() { FlightId = 4, FlightCode = "000XS02", DepartureAirportId = 1, ArrivalAirportId = 3, Price = 190.00M, DepartureDateTime = new DateTime(2020, 07, 20, 23, 15, 00), ArrivalDateTime = new DateTime(2020, 07, 21, 02, 00, 00), MaxNumberSeats = 20 },
                new Flight() { FlightId = 5, FlightCode = "000XR01", DepartureAirportId = 3, ArrivalAirportId = 1, Price = 240.00M, DepartureDateTime = new DateTime(2020, 07, 21, 13, 50, 00), ArrivalDateTime = new DateTime(2020, 07, 21, 15, 30, 00), MaxNumberSeats = 15 },
                new Flight() { FlightId = 6, FlightCode = "000XS02", DepartureAirportId = 3, ArrivalAirportId = 1, Price = 190.00M, DepartureDateTime = new DateTime(2020, 07, 21, 22, 45, 00), ArrivalDateTime = new DateTime(2020, 07, 22, 01, 00, 00), MaxNumberSeats = 15 },
                new Flight() { FlightId = 7, FlightCode = "000XT01", DepartureAirportId = 3, ArrivalAirportId = 2, Price = 140.00M, DepartureDateTime = new DateTime(2020, 07, 21, 10, 15, 00), ArrivalDateTime = new DateTime(2020, 07, 21, 12, 30, 00), MaxNumberSeats = 15 },
                new Flight() { FlightId = 8, FlightCode = "000XS02", DepartureAirportId = 3, ArrivalAirportId = 1, Price = 250.00M, DepartureDateTime = new DateTime(2020, 07, 22, 10, 15, 00), ArrivalDateTime = new DateTime(2020, 07, 22, 12, 45, 00), MaxNumberSeats = 15 },
                new Flight() { FlightId = 9, FlightCode = "000XS02", DepartureAirportId = 1, ArrivalAirportId = 3, Price = 220.00M, DepartureDateTime = new DateTime(2020, 07, 22, 06, 50, 00), ArrivalDateTime = new DateTime(2020, 07, 22, 08, 30, 00), MaxNumberSeats = 15 },
                new Flight() { FlightId = 10, FlightCode = "000XS02", DepartureAirportId = 1, ArrivalAirportId = 3, Price = 320.00M, DepartureDateTime = new DateTime(2020, 07, 22, 16, 25, 00), ArrivalDateTime = new DateTime(2020, 07, 22, 18, 20, 00), MaxNumberSeats = 15 },
                new Flight() { FlightId = 11, FlightCode = "000XR01", DepartureAirportId = 3, ArrivalAirportId = 1, Price = 225.00M, DepartureDateTime = new DateTime(2020, 07, 22, 19, 30, 00), ArrivalDateTime = new DateTime(2020, 07, 22, 20, 55, 00), MaxNumberSeats = 15 }
            );

            modelBuilder.Entity<BookedFlight>().HasData(
                new BookedFlight() { BookedFlightId = 1, CustomerName = "Joe Doe", Seat = "1a", FlightId = 3 },
                new BookedFlight() { BookedFlightId = 2, CustomerName = "Joe Doe", Seat = "12b", FlightId = 3 },
                new BookedFlight() { BookedFlightId = 3, CustomerName = "Joe Doe", Seat = "5a", FlightId = 3 },
                new BookedFlight() { BookedFlightId = 4, CustomerName = "Joe Doe", Seat = "1c", FlightId = 3 },
                new BookedFlight() { BookedFlightId = 5, CustomerName = "Joe Doe", Seat = "3c", FlightId = 5 },
                new BookedFlight() { BookedFlightId = 6, CustomerName = "Joe Doe", Seat = "5a", FlightId = 5 },
                new BookedFlight() { BookedFlightId = 7, CustomerName = "Joe Doe", Seat = "4a", FlightId = 5 },
                new BookedFlight() { BookedFlightId = 8, CustomerName = "Joe Doe", Seat = "1a", FlightId = 5 }
            );
        }
    }
}