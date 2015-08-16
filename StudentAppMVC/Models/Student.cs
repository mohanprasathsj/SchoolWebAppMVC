using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAppMVC.Models
{
    public class Student:Basic
    {
        public Guid StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("SchoolClass")]
        public virtual Guid StudentClassId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Parent Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string ParentEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public int PhoneNumber { get; set; }
    }
}