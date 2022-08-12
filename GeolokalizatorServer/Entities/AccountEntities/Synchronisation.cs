using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Entities
{
    public class Synchronisation
    {
        public int ID { get; set; }
        public string DeviceName { get; set; }
        public DateTime LastSynchronisationTime { get; set; }
        public DateTime FirstSynchronisation { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
