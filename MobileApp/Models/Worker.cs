    using SQLite;

namespace MobileApp.Models
{
    public class Worker
    {
        [PrimaryKey]
        public int Workerid { get; set; }
        public string Nameworker { get; set; }
        public string Lastnameworker { get; set; }
        public string Passworker { get; set; }

    }
}