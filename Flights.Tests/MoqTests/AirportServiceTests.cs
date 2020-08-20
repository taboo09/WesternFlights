using System.Collections.Generic;
using System.Linq;
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
    public class AirportServiceTests
    {
        private readonly Mock<IAppRepository<FlightDbContext>> _appRepositoryMock;
        private readonly AirportService _sut;

        public AirportServiceTests()
        {
            _appRepositoryMock = new Mock<IAppRepository<FlightDbContext>>();
            _sut = new AirportService(_appRepositoryMock.Object);
        }

        [Fact]
        public async Task AllAirports_ReturnsAiports_WhenRecordsExist()
        {
            // Arrange
            var airports = new List<Airport>()
            {
                new Airport { AirportId = 101, AirportCode = "CCC", AirportCity = "London" },
                new Airport { AirportId = 102, AirportCode = "RTC", AirportCity = "Berlin" }
            };

            // build mock by extension for
            // "ToListAsync" method
            var airportsMock = airports.AsQueryable().BuildMock();

            _appRepositoryMock.Setup(x => x.GetAll<Airport>()).Returns(airportsMock.Object);

            // Act
            var result = await _sut.AllAirports();

            // Assert
            result.Should().HaveCount(c => c == 2);
        }

        [Fact]
        public async Task AllAirports_ReturnsEmptyList_WhenRecordsDontExist()
        {
            var airportsMock = Enumerable.Empty<Airport>().AsQueryable().BuildMock();

            _appRepositoryMock.Setup(x => x.GetAll<Airport>()).Returns(airportsMock.Object);

            var result = await _sut.AllAirports();

            result.Should().BeEmpty();
        }
    }
}