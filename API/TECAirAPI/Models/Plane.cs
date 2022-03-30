/// <summary>
/// Creation of Plane Model with its attributes
/// </summary>

namespace TECAirAPI.Models
{
    public class Plane
    {
        public int PlaneID { get; set; } //Primary Key
        
        //Atributtes 
        public string Model { get; set; }
        public int PassangerCap { get; set; }
        public int BagCap { get; set; }
    }
}