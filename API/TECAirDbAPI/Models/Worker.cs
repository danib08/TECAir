using System;
using System.Collections.Generic;

#nullable disable

namespace TECAirDbAPI.Models
{
    public partial class Worker
    {
        /*public Worker()
        {
            Flights = new HashSet<Flight>();
        }*/

        public int Workerid { get; set; }
        public string Nameworker { get; set; }
        public string Lastnameworker { get; set; }
        public string Passworker { get; set; }

        //public virtual ICollection<Flight> Flights { get; set; }
    }
}
