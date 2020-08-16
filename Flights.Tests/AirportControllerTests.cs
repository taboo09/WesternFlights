using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Flights.Application.Dtos;
using FluentAssertions;
using Xunit;

namespace Flights.Tests
{
    public class AirportControllerTests : IntegrationTests
    {
        [Fact]
        public async Task Aiports_WithNoRecords_ReturnsOkAndListOfAllAirports()
        {
            var response = await _client.GetAsync("airport");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var list = await JsonSerializer.DeserializeAsync<List<AirportDto>>(await response.Content.ReadAsStreamAsync());

            list.Should().HaveCount(c => c == 5);
        }
    }
}