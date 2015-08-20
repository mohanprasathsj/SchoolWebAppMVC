using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAppMVC.Models
{
    public class SchoolClass : Basic
    {
        public SchoolClass()
        {
            StandardId = Guid.Parse("E7B6C384-C1D5-489A-A727-6DF12B9FE41A");
        }

        public virtual List<Subject> Subjects { get; set; }

        public virtual List<Student> Students { get; set; }

        public Guid SchoolClassId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Standard")]
        public virtual Guid StandardId { get; set; }

        public virtual Standard Standard { get; set; }


    }
}