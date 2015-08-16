using System;
using System.Collections.Generic;

namespace StudentAppMVC.Models
{
    public class Subject:Basic
    {
        public Guid SubjectId { get; set; }

        public string Name { get; set; }

        public virtual ParentSubject ParentSubject { get; set; }

        public virtual SchoolClass Class { get; set; }

    }
}