﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamManagement.Models
{
    public class Ent_Question
    {
        
        

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
        public virtual ICollection<TestXQuestionz> TestXQuestions { get; set; }
    }
}