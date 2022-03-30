namespace TECAirAPI.Models
{
    public class Plane
    {
        public int PlaneID { get; set; } //Primary Key Plane 

        //Attributes
        public string Model {get; set;} 

        public int PassangerCap {get; set;}

        public int BagCap {get; set;}
    }
}