using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Models
{
    public class SynchronizationDto
    {
        public int UserId { get; set; }
        public int DeviceNumber { get; set; }
        public string TimeZone { get; set; }
        public DateTime NewSynchronizationDate { get; set; }
    }
}
