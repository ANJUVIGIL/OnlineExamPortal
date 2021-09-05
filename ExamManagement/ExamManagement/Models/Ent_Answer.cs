using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class Ent_Answer
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int TestXQuestionId { get; set; }
        public int ChoiceId { get; set; }
        public string Answer { get; set; }
        public Nullable<decimal> MarkScored { get; set; }
        public virtual Choice Choice { get; set; }
        public virtual TestXQuestionz TestXQuestion { get; set; }
    }
}