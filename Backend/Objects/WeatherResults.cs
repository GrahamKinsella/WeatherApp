using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Objects
{
    public class WeatherResults
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public double Temperature { get; set; }
        public double RealFeel { get; set; }
        public double Humidity { get; set; }
        public double UvIndex { get; set; }
        public string WindSpeed { get; set; }
    }
}
