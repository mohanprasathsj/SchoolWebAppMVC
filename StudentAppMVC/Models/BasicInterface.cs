using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentAppMVC.Models
{
    
    public class Basic
    {
        [Display(AutoGenerateField = false)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(AutoGenerateField = false)]
        public Guid CreatedBy { get; set; } = Guid.Parse("56939C30-59C7-4957-BB11-3673EB67CACD");

        [Display(AutoGenerateField = false)]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [Display(AutoGenerateField = false)]
        public Guid UpdatedBy { get; set; } = Guid.Parse("56939C30-59C7-4957-BB11-3673EB67CACD");
    }
}
