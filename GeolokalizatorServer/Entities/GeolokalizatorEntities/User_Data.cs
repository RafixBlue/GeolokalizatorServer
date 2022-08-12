﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Entities
{
    public class User_Data
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int SignalID { get; set; }
        public virtual Signal Signal { get; set; }

        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}