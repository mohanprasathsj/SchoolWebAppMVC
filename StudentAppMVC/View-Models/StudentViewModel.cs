using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace StudentAppMVC.View_Models
{
    public class StudentViewModel
    {
        public Guid StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Class")]
        public Guid StudentClassId { get; set; }

        public IEnumerable<SelectListItem> Classes { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Parent Email")]
        [DataType(DataType.EmailAddress)]
        public string ParentEmail { get; set; }

        [Required]
        public int PhoneNumber { get; set; }


    }
}
