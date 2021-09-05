using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class StudentResult
    {
       
        public int TestId { get; set; }
        public int RegistrationId { get; set; }
        public Nullable<decimal> MarkScored { get; set; }
     
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
    }
}