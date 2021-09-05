using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Registration
    {
        public int Rid { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}
