using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAppMVC.Models
{
    public class Subject:Basic
    {
        public Guid SubjectId { get; set; }

        public string Name { get; set; }

        //public virtual ParentSubject ParentSubject { get; set; }
        [ForeignKey("SchoolClass")]
        public virtual Guid ClassId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }

    }
}