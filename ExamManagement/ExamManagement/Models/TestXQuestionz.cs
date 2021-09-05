using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class TestXQuestionz
    {
         public TestXQuestionz()
        {
            this.QuestionXDurations = new List<QuestionXDuration>();
            this.TestXPapers = new List<TestXPaper>();
        }

        public int Id { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public bool isactive { get; set; }
        public virtual Questionz Question { get; set; }
        public virtual ICollection<QuestionXDuration> QuestionXDurations { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<TestXPaper> TestXPapers { get; set; }
    }
    }
