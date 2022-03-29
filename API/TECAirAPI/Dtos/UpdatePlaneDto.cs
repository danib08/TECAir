namespace TECAirAPI.Dtos
{
    public class UpdatePlaneDto
    {
        public int PlaneID { get; set; }
        public string Model { get; set; }
        public int PassangerCap { get; set; }
        public int BagCap { get; set; }
    }
}