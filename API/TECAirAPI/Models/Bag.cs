namespace TECAirAPI.Models

{
    public class Bag
    {
        public int BagID { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public int WorkerID { get; set; }  //Foreign Key
        public Worker worker { get; set; } //Reference navigation property
    }
}