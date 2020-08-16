using System;
using System.Net.Http;
using Flights.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Flights.Tests
{
    public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public IntegrationTests()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false,
                    BaseAddress = new Uri("http://localhost:5055/api/")
                });
        }
    }
}