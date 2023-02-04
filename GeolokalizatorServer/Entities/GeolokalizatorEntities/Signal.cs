using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Entities
{
    public class Signal
    {
        public int ID { get; set; }
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
    }
}
