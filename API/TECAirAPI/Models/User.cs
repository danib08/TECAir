using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Creation of User Model with its attributes
/// </summary>
namespace TECAirAPI.Models
{
    public class User
    {
        [Range(100000000, 999999999)] //Restriction for User's ID
        public int UserID { get; set; } //Primary Key
       //Atributtes
        public string NameUser { get; set; }
        public string LastNameUser { get; set; }
        public string PassUser { get; set; }
        public string Email { get; set; }

        [Range(20000000, 89999999)] //Restriction for Phone number
        public int Phone{get; set;}
        public int StudentID {get; set;}
        public string University{get; set;}
        public int Miles{get; set;}
    }
}