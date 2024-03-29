﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Models
{
    public class CollectedDataMapDto
    {
        public string DateTime { get; set; }
        public string Latitude { get; set; }
        public string Altitude { get; set; }
        public string Longitude { get; set; }
        public string Accuracy { get; set; }

        public string Network_Provider { get; set; }
        public string Network_Type { get; set; }
        public string RSSI { get; set; }
        public string RSRP { get; set; }
        public string RSRQ { get; set; }
        public string RSSNR { get; set; }
        public string TimeZone { get; set; }
    }
}
