using Backend.Objects;
using GoogleMaps.LocationServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Helpers
{
    public class Geolocation
    {
        private readonly IConfiguration _configuration;
        public Geolocation(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Coordinates GetLatAndLong(string location)
        {
            var address = new AddressData
            {
                City = "DUBLIN",
                State = null,
                Country = "IRELAND",
                Zip = "D05Y996"
            };

            var key = _configuration["GoogleApiKey"];
            var locationService = new GoogleLocationService(apikey: key);

            var point = locationService.GetLatLongFromAddress(address);

            Coordinates co = new Coordinates()
            {
                Lat = point.Latitude.ToString(),
                Long = point.Longitude.ToString()
            };

            return co;
        }
    }
}

