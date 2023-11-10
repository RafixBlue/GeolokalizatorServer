using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Entities
{
    public class Label
    {
        public int ID { get; set; }
        public string Place { get; set; }
        public string StartDate { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }

    }
}
