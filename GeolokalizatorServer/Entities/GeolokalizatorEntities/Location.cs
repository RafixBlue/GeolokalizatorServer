using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Entities
{
    public class Location
    {
        public int ID { get; set; }
        public string Latitude { get; set; }
        public string Altitude { get; set; }
        public string Longitude { get; set; }
        public string Accuracy { get; set; }
        public string Speed { get; set; }
        public string SpeedAccuracy { get; set; }
    }
}
