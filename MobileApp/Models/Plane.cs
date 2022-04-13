using SQLite;


namespace MobileApp.Models
{
    class Plane
    {
        [PrimaryKey]
        public string Planeid { get; set; }
        public string Model { get; set; }
        public int Passangercap { get; set; }
        public int Bagcap { get; set; }
    }
}
