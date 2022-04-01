using System;
using System.Collections.Generic;

#nullable disable

namespace TECAirDbAPI.Models
{
    public partial class Customer
    {
        /*public Customer()
        {
            Bags = new HashSet<Bag>();
        }*/

        public int Customerid { get; set; }
        public string Namecustomer { get; set; }
        public string Lastnamecustomer { get; set; }
        public string Passcustomer { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int? Studentid { get; set; }
        public string University { get; set; }
        public int? Miles { get; set; }

        //public virtual ICollection<Bag> Bags { get; set; }
    }
}
