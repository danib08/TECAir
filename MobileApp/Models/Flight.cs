﻿using SQLite;
using System;

namespace MobileApp.Models
{
    public class Flight
    {
        [PrimaryKey]
        public string Flightid { get; set; }
        public int Bagquantity { get; set; }
        public int Userquantity { get; set; }
        public int Gate { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }

        //foreign keys
        public string Planeid { get; set; }
        public int Workerid { get; set; }

    }
}