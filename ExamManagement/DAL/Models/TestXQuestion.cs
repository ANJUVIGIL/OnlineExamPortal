using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TestXQuestion
    {
        public TestXQuestion()
        {
            this.QuestionXDurations = new List<QuestionXDuration>();
            this.TestXPapers = new List<TestXPaper>();
        }

        public int Id { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public bool isactive { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<QuestionXDuration> QuestionXDurations { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<TestXPaper> TestXPapers { get; set; }
    }
}
