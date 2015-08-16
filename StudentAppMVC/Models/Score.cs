using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAppMVC.Models
{
    public class Score:Basic
    {
        public Guid ScoreId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Student Student { get; set; }

        public virtual Exam Exam { get; set; }

        public int ScoreValue { get; set; }
        
    }
}
