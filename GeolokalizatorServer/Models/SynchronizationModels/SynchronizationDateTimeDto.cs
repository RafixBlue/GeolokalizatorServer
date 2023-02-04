using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Models
{
    public class SynchronizationDateTimeDto
    {
        public string TimeZone { get; set; }
        public DateTime MeasurementTime { get; set; }
    }
}
