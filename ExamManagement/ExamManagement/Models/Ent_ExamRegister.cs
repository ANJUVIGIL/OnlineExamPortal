using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class Ent_ExamRegister
    {
        public int ExamId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public Nullable<System.Guid> Token { get; set; }
        public Nullable<System.DateTime> TokenExpireTime { get; set; }
        public virtual Registration Registration { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<QuestionXDuration> QuestionXDurations { get; set; }
        public virtual ICollection<TestXPaper> TestXPapers { get; set; }
    }
}