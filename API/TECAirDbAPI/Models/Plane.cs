using System;
using System.Collections.Generic;

#nullable disable

namespace TECAirDbAPI.Models
{
    public partial class Plane
    {
        public Plane()
        {
            Flights = new HashSet<Flight>();
        }

        public string Planeid { get; set; }
        public string Model { get; set; }
        public int Passengercap { get; set; }
        public int Bagcap { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
