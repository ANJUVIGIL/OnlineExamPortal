using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class QuestionXDuration
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int TestXQuestionId { get; set; }
        public System.DateTime RequestTime { get; set; }
        public Nullable<System.DateTime> LeaveTime { get; set; }
        public Nullable<System.DateTime> AnsweredTime { get; set; }
        public virtual ExamRegistration ExamRegistration { get; set; }
        public virtual TestXQuestion TestXQuestion { get; set; }
    }
}
