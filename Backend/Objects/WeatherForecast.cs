using Newtonsoft.Json;
using System;

namespace Backend
{
    public class WeatherForecast
    {
        [JsonProperty]
        public Current current { get; set; }

    }

    public class Current
    {
        [JsonProperty]
        public DateTime sunrise { get; set; }
        [JsonProperty]
        public DateTime sunset { get; set; }
        [JsonProperty]
        public double temp { get; set; }
        [JsonProperty]
        public double feels_like { get; set; }
        [JsonProperty]
        public double humidity { get; set; }
        [JsonProperty]
        public double uvi { get; set; }
        [JsonProperty]
        public string wind_speed { get; set; }
    }
}
