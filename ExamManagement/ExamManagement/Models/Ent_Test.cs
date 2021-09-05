using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class Ent_Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> isactive { get; set; }
        public Nullable<int> DurationInMinute { get; set; }
        public virtual ICollection<ExamRegistration> ExamRegistrations { get; set; }
        public virtual ICollection<TestXQuestionz> TestXQuestions { get; set; }
    }
}