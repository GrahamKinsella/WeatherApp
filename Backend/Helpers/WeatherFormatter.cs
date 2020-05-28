using Backend.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Helpers
{
    public static class WeatherFormatter
    {
        public static WeatherResults FormatWeather(RawWeather rw)
        {
            var weatherResults = new WeatherResults
            {
                Sunrise = DateTime.UnixEpoch.AddSeconds(rw.current.sunrise).ToShortTimeString(),
                Sunset = DateTime.UnixEpoch.AddSeconds(rw.current.sunset).ToShortTimeString(),
                Temperature = Math.Round(rw.current.temp - 273.15),
                RealFeel = Math.Round(rw.current.feels_like - 273.15),
                Humidity = rw.current.humidity,
                UvIndex = rw.current.uvi,
                WindSpeed = rw.current.wind_speed
            };
           return weatherResults;
        }
    }
}
