using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class QuestionCategory
    {
        public QuestionCategory()
        {
            this.Questions = new List<Question>();
        }

        public int Cid { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
