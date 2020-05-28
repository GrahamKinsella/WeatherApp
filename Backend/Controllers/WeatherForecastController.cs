using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Helpers;
using Backend.Objects;
using GoogleMaps.LocationServices;
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

        [HttpPost]
        [Route("api/sendAddress")]
        public async Task<WeatherResults> Get([FromBody]AddressData address)
        {
            Geolocation gl = new Geolocation(_configuration);

            //var address = JsonConvert.DeserializeObject<AddressData>(rawAddress);

            Coordinates coordinates = gl.GetLatAndLong(address);

            string key = _configuration["OpenWeatherApiKey"];
            var request = $"https://api.openweathermap.org/data/2.5/onecall?lat={coordinates.Lat}&lon={coordinates.Long}&exclude=hourly,daily&appid={key}";
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            //TODO: Create object to deserialize to
            var forecast = JsonConvert.DeserializeObject<RawWeather>(responseBody);

            //convert values to readable values - check if you need json property
            var results = WeatherFormatter.FormatWeather(forecast);

            return results;

        }
    }
}