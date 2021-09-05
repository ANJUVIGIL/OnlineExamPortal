using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Question
    {
        public Question()
        {
            this.Choices = new List<Choice>();
            this.TestXQuestions = new List<TestXQuestion>();
        }

        public int Qid { get; set; }
        public int QCid { get; set; }
        public string QuestionType { get; set; }
        public string Question1 { get; set; }
        public Nullable<int> ExhibitId { get; set; }
        public int points { get; set; }
        public bool isactive { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual Exhibit Exhibit { get; set; }
        public virtual QuestionCategory QuestionCategory { get; set; }
        public virtual ICollection<TestXQuestion> TestXQuestions { get; set; }
    }
}
