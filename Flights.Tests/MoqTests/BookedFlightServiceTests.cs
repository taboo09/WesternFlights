using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Flights.Application.Services;
using Flights.Domain.Core;
using Flights.Domain.Models;
using Flights.Infrastructure.Context;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Flights.Tests.MoqTests
{
    public class BookedFlightServiceTests
    {
        private readonly Mock<IAppRepository<FlightDbContext>> _appRepositoryMock;
        private readonly BookedFlightService _sut;
        private readonly List<BookedFlight> _bookedFlights;

        public BookedFlightServiceTests()
        {
            _appRepositoryMock = new Mock<IAppRepository<FlightDbContext>>();
            _sut = new BookedFlightService(_appRepositoryMock.Object);

            _bookedFlights = new List<BookedFlight>()
            {
                new BookedFlight { BookedFlightId = 1, CustomerName = "John Smith", Seat = "1a", FlightId = 101 },
                new BookedFlight { BookedFlightId = 2, CustomerName = "Joe Doe", Seat = "3c", FlightId = 101 },
                new BookedFlight { BookedFlightId = 3, CustomerName = "John Smith", Seat = "12a", FlightId = 102 }
            };
        }

        [Theory]
        [InlineData(101, 2)]
        [InlineData(102, 1)]
        [InlineData(103, 0)]
        public async Task GetUnavailableSeats_ReturnsListOfString_WhenSeatsExistOrNot(int flightId, int seatsCount)
        {
            var bookedFlightsMock = _bookedFlights.AsQueryable().BuildMock();

            _appRepositoryMock.Setup(x => x.GetAll<BookedFlight>()).Returns(bookedFlightsMock.Object);

            var result = await _sut.GetUnavailableSeats(flightId);

            result.Should().HaveCount(c => c == seatsCount);
        }

        [Fact]
        public async Task CheckSeat_ReturnsFalse_WhenSeatIsUnavailable()
        {
            var bookedFlight = _bookedFlights.Find(x => x.BookedFlightId == 1);

            _appRepositoryMock.Setup(x => x.FindEntity<BookedFlight>(It.IsAny<Expression<Func<BookedFlight, bool>>>())).ReturnsAsync(bookedFlight);

            var result = await _sut.CheckSeat(101, "Seat_number");

            result.Should().BeFalse();
        }

        [Fact]
        public async Task CheckSeat_ReturnsTrue_WhenSeatIsAvailable()
        {
            _appRepositoryMock.Setup(x => x.FindEntity<BookedFlight>(It.IsAny<Expression<Func<BookedFlight, bool>>>())).ReturnsAsync((BookedFlight)null);

            var result = await _sut.CheckSeat(101, "seat_number");

            result.Should().BeTrue();
        }
    }
}