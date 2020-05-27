using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Helpers;
using Backend.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        public WeatherForecastController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public async void Get()
        {
            Map map = new Map(_configuration);
            var location = "Dublin, Ireland";
            Coordinates coordinates = map.GetLatAndLong(location);

            string key = _configuration["OpenWeatherApiKey"];
            var request = $"https://api.openweathermap.org/data/2.5/onecall?lat={coordinates.Lat}&lon={coordinates.Long}&exclude=hourly,daily&appid={key}";
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            //TODO: Create object to deserialize to
            var forecast = JsonConvert.DeserializeObject<WeatherForecast>(responseBody);

            //convert values to readable values - check if you need json property
        }
    }
}