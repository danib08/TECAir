namespace TECAirAPI.Dtos
{
    public class CreateBagDto
    {
        public int BagID { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public int WorkerID { get; set; }

    }
}