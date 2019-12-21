using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using WebAPIIntergrationTestDemo;
using WebAPIIntergrationTestDemo.Controllers;
using Xunit;

namespace WebAPIIntegrationTestDemo.Tests
{
  
    public class BasicTests : IClassFixture<WebApplicationFactory<WebAPIIntergrationTestDemo.Startup>>
    {
        private readonly WebApplicationFactory<WebAPIIntergrationTestDemo.Startup> _factory;

       
        public BasicTests(WebApplicationFactory<WebAPIIntergrationTestDemo.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetWeather()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("WeatherForecast");

            var contents = await response.Content.ReadAsStringAsync();
            var  weatherList = JsonConvert.DeserializeObject<IList<WeatherForecast>>(contents);

            response.ShouldNotBeNull();
            weatherList.Count.ShouldBeGreaterThan(0);
        }
    }
}
