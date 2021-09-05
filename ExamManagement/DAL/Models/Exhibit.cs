using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Exhibit
    {
        public Exhibit()
        {
            this.Questions = new List<Question>();
        }

        public int Eid { get; set; }
        public string ExhibitData { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
