using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Flights.Application.Dtos;
using FluentAssertions;
using Xunit;

namespace Flights.Tests
{
    public class BookedFlightsControllerTest : IntegrationTests
    {
        [Theory]
        [InlineData(3, 4)]
        [InlineData(5, 4)]
        [InlineData(4, 0)]
        public async Task SelectedSeats_FlightId_ReturnsSelectedSeats(int flightId, int seatsCount)
        {
            var response = await _client.GetAsync($"bookedflights/seats/{flightId}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var list = await JsonSerializer.DeserializeAsync<List<string>>(await response.Content.ReadAsStreamAsync());

            list.Should().HaveCount(c => c == seatsCount);
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(1, 3)]
        public async Task AllBookedFlights_Pagination5PerPage_ReturnBookedFlights(int pageNumber, int pageSize)
        {
            var response = await _client.GetAsync($"bookedflights?page={pageNumber}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var list = await JsonSerializer.DeserializeAsync<List<BookedFlightReturnDto>>(await response.Content.ReadAsStreamAsync());

            list.Should().HaveCount(c => c == pageSize);
        }

        [Fact]
        public async Task NewBookedFlights_NullObject_ReturnsBadRequest()
        {
            var content = new StringContent(JsonSerializer.Serialize(new List<NewBookedFlightDto>()), Encoding.UTF8, "application/json"); 
            
            var response = await _client.PostAsync("bookedflights", content: content);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData(3, "1a")]
        [InlineData(5, "3c")]
        public async Task NewBookedFlights_SingleObjectWithSeatNotAvailable_ReturnsBadRequest(int flightId, string seat)
        {
            var flights = new List<NewBookedFlightDto>()
            {
                new NewBookedFlightDto() 
                {
                    CustomerName = "John Smith",
                    Seat = seat,
                    FlightId = flightId
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(flights), Encoding.UTF8, "application/json"); 
            
            var response = await _client.PostAsync("bookedflights", content: content);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData(3, "1b")]
        [InlineData(5, "1c")]
        public async Task NewBookedFlights_SingleObjectWithSeatAvailable_ReturnsOK(int flightId, string seat)
        {
            var flights = new List<NewBookedFlightDto>()
            {
                new NewBookedFlightDto() 
                {
                    CustomerName = "John Smith",
                    Seat = seat,
                    FlightId = flightId
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(flights), Encoding.UTF8, "application/json"); 
            
            var response = await _client.PostAsync("bookedflights", content: content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task NewBookedFlights_ReturnFlightSelectedWithSeatAvailable_ReturnsOK()
        {
            var flights = new List<NewBookedFlightDto>()
            {
                new NewBookedFlightDto() 
                {
                    CustomerName = "John Smith",
                    Seat = "1b",
                    FlightId = 3
                },
                new NewBookedFlightDto() 
                {
                    CustomerName = "John Smith",
                    Seat = "1c",
                    FlightId = 5
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(flights), Encoding.UTF8, "application/json"); 
            
            var response = await _client.PostAsync("bookedflights", content: content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}