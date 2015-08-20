using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentAppMVC.Models
{
    
    public class Basic
    {
        public Basic()
        {
            CreatedBy = Guid.Parse("56939C30-59C7-4957-BB11-3673EB67CACD");
            UpdatedBy = Guid.Parse("56939C30-59C7-4957-BB11-3673EB67CACD");
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        [Display(AutoGenerateField = false)]
        public DateTime CreatedDate { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CreatedBy { get; set; }

        [Display(AutoGenerateField = false)]
        public DateTime UpdatedDate { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid UpdatedBy { get; set; }
    }
}
