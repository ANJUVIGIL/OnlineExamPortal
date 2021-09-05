using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ExamRegistration
    {
        public ExamRegistration()
        {
            this.QuestionXDurations = new List<QuestionXDuration>();
        }

        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int TestId { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public System.Guid Token { get; set; }
        public System.DateTime TokenExpireTime { get; set; }
        public virtual Student Student { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<QuestionXDuration> QuestionXDurations { get; set; }
    }
}
