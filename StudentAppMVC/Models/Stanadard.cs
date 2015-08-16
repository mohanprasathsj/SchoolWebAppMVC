using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAppMVC.Models
{
    public class Standard:Basic
    {
       
        public Guid StandardId { get; set; }

        public string Name { get; set; }

        public virtual List<SchoolClass> Classes { get; set; }
    }
}
