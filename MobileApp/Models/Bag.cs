using SQLite;

namespace MobileApp.Models
{
    class Bag
    {
        [PrimaryKey]
        public string Bagid { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int Customerid { get; set; }
        public string Flightid { get; set; }
    }
}