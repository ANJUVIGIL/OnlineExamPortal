using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Test
    {
        public Test()
        {
            this.ExamRegistrations = new List<ExamRegistration>();
            this.TestXQuestions = new List<TestXQuestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isactive { get; set; }
        public int DurationInMinute { get; set; }
        public virtual ICollection<ExamRegistration> ExamRegistrations { get; set; }
        public virtual ICollection<TestXQuestion> TestXQuestions { get; set; }
    }
}
