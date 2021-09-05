using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Choice
    {
        public Choice()
        {
            this.TestXPapers = new List<TestXPaper>();
        }

        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public string Label { get; set; }
        public decimal points { get; set; }
        public bool isactive { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<TestXPaper> TestXPapers { get; set; }
    }
}
