using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Student
    {
        public Student()
        {
            this.ExamRegistrations = new List<ExamRegistration>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AccessLevel { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassHash { get; set; }
        public virtual ICollection<ExamRegistration> ExamRegistrations { get; set; }
    }
}
