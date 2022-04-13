using System;
using System.Collections.Generic;

#nullable disable

namespace TECAirDbAPI.Models
{
    //Plane Model generated from DbContext
    public partial class Plane
    {

        public string Planeid { get; set; }
        public string Model { get; set; }
        public int Passengercap { get; set; }
        public int Bagcap { get; set; }

    }
}
