using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Creation of Worker Model with its attributes
/// </summary>

namespace TECAirAPI.Models
{
    
    public class Worker
    {
        [Range(100000000, 999999999)] //Restriction for Worker's ID
        public int WorkerID { get; set; } //Primary Key

        //Atributtes
        public string NameWorker { get; set; }
        public string LastNameWorker { get; set; }
        public string PassWorker { get; set; }
        public List<Bag> Bags { get; set; }  //Collection navigation property

    }
}