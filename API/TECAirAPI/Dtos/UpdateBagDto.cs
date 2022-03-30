namespace TECAirAPI.Dtos
{
    public class UpdateBagDto
    {
        public int BagID { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public int UserID { get; set; }
        public int FlightID { get; set; }

    }
}