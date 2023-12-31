﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJsonSerializerDeseri.Models
{
    public class Location
    {
        public Street Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public Coordinates Coordinates { get; set; }
        public Timezone Timezone { get; set; }
    }
}
