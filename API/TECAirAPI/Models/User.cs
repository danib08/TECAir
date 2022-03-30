namespace TECAirAPI.Models
{
    public class User
    {
        public int UserID { get; set; } //Primary Key

        //Atributtes
        public string NameUser { get; set; }
        public string LastNameUser { get; set; }
        public string PassUser { get; set; }

        public int Phone { get; set; }
        public string Email {get; set;}
        public int StudentID {get; set;}
        public string University {get; set;}
        public int Miles {get; set;}
    }
}