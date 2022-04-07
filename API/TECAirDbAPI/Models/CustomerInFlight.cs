using System;
using System.Collections.Generic;

#nullable disable

namespace TECAirDbAPI.Models
{
    public partial class CustomerInFlight
    {
        public string Seatnum { get; set; }
        public int Customerid { get; set; }
        public string Flightid { get; set; }

    }
}
