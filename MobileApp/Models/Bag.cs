using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp.Models
{
    class Bag
    {
        [PrimaryKey]
        public string Bagid { get; set; }
        public int Weight { get; set; }
        public int Color { get; set; }
        public int Price { get; set; }
        public int Customerid { get; set; }
        public string Flightid { get; set; }
    }
}