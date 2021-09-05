using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class Ent_Register
    {
        [ScaffoldColumn(false)]
        public int Rid { get; set; }
        //[Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number Required!")]
        [Display(Name = "Home Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        //[Required]
        public string Department { get; set; }
        //[Required]
        public string Image { get; set; }

        //[Required(ErrorMessage = "Choose your gender")]
        //public string gender { get; set; }
        //[Required]
        //public string username { get; set; }
        //[Required]
        public string password { get; set; }

        
        public string EntryDate { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}