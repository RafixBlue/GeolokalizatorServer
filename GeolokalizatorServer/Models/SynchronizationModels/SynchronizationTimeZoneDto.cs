using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Models
{
    public class SynchronizationTimeZoneDto
    {
        public string TimeZone { get; set; }
        public string LastSynchronization { get; set; }
    }
}
