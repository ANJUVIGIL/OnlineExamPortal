using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class Ent_Choice
    {
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public string Label { get; set; }
        public decimal points { get; set; }
        public bool isactive { get; set; }
        public virtual Questionz Question { get; set; }
        public virtual ICollection<TestXPaper> TestXPapers { get; set; }
    }
}