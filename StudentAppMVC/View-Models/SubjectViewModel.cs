using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StudentAppMVC.View_Models
{
    public class SubjectViewModel
    {
        public Guid SubjectId { get; set; }

        public string Name { get; set; }

        [Display(Name="Class")]
        public Guid ClassId { get; set; }

        public IEnumerable<SelectListItem> Classes { get; set; }
    }
}
