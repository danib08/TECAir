/// <summary>
/// Bag Model with its attributes and restrictions
/// </summary>

namespace TECAirAPI.Models

{
    public class Bag
    {
        public int BagID { get; set; } //Primary Key Bag
        public int Weight { get; set; }
        public string Color { get; set; }
        
        //public int UserID { get; set; }  //Foreign Key from User

        //public int FlightID{get; set;}   //Foreign Key from Flight

         
        
        //public User user{get; set;} //Reference navigation property from User
        //public Flight flight { get; set; } //Reference navigation property
    }
}