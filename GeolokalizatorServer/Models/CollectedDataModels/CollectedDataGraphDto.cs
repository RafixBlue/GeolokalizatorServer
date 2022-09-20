using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Models
{
    public class CollectedDataGraphDto
    {
        public string DateTime { get; set; }
        public string Accurency { get; set; }
        public string Network_Provider { get; set; }
        public string Network_Type { get; set; }
        public string RSSI { get; set; }
        public string RSRP { get; set; }
        public string RSRQ { get; set; }
        public string RSSNR { get; set; }
    }
}
