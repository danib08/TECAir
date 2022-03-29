using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TECAirAPI.Models
{
    
    public class Worker
    {
        [Range(100000000, 999999999)]
        public int WorkerID { get; set; }
        public string NameWorker { get; set; }
        public string LastNameWorker { get; set; }
        public string PassWorker { get; set; }
        public List<Bag> Bags { get; set; }  //Collection navigation property

    }
}