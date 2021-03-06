using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TestXPaper
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int TestXQuestionId { get; set; }
        public int ChoiceId { get; set; }
        public string Answer { get; set; }
        public Nullable<decimal> MarkScored { get; set; }
        public virtual Choice Choice { get; set; }
        public virtual TestXQuestion TestXQuestion { get; set; }
    }
}
