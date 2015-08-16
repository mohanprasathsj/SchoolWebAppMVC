using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAppMVC.Models
{
    public class Exam:Basic
    {
        public Guid ExamId { get; set; }

        public string Name { get; set; }

    }
}
