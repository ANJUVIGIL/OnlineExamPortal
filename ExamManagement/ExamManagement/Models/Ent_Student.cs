using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class Ent_Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccessLevel { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassHash { get; set; }
    }
}