using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Entities
{
    public class Synchronization
    {
        public int ID { get; set; }

        public DateTime LastSynchronization { get; set; }

        public string TimeZone { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
