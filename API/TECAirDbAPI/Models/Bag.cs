using System;
using System.Collections.Generic;

#nullable disable

namespace TECAirDbAPI.Models
{
    //Bag Model generated from DbContext

    public partial class Bag
    {
        public string Bagid { get; set; }
        public int? Weight { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int? Customerid { get; set; }
        public string Flightid { get; set; }

    }
}
