using SQLite;


namespace MobileApp.Models
{
    class Customer
    {

        [PrimaryKey]
        public int Customerid { get; set; }
        public string namecustomer { get; set; }
        public string lastnamecustomer { get; set; }
        public string passcustomer { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public int studentid { get; set; }
        public string university { get; set; }
        public int miles { get; set; }
    }
}