using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TL_LMS.Models
{
    public class AllData
    {
        
        public IEnumerable<Registration> registrations { get; set; }
        public IEnumerable<Student> students { get; set; }
        public IEnumerable<Teacher> teachers { get; set; }
        public IEnumerable<Cours> courses { get; set; }

    }   
}