using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Models.CollectedDataModels
{
    public class CollectedDataDto
    {
        public int UserId { get; set; }
        public string MeasurementTime { get; set; }
        public string TimeZone { get; set; }

        public string Latitude { get; set; }
        public string Altitude { get; set; }
        public string Longitude { get; set; }
        public string Accuracy { get; set; }
        public string Speed { get; set; }
        public string SpeedAccuracy { get; set; }

        public string Network_Provider { get; set; }
        public string Network_Type { get; set; }
        public string Bandwidth { get; set; }
        public string Earfcn { get; set; }
        public string Tac { get; set; }
        public string Asu { get; set; }
        public string Ta { get; set; }
        public string Rssi { get; set; }
        public string Rsrp { get; set; }
        public string Rsrq { get; set; }
        public string Rssnr { get; set; }

        public string Place { get; set; }
        public string StartDate { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }

    }
}
