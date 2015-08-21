using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentAppMVC.View_Models
{
    public class SubjectListViewModel
    {
        [Display(Name="Subject")]
        public Guid SubjectId { get; set; }

        public IEnumerable<SelectListItem> Subjects { get; set; }
    }
}
