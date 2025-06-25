using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Airport
    {
        public int Id { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float TimezoneOffset { get; set; }
        public string TZ_DB { get; set; }
        public AirportName AirportName { get; set; }
    }

    public class AirportName
    {
        public string Culture { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
