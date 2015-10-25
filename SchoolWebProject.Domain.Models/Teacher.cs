using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    class Teacher:User
    {
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public Teacher()
        {

        }
    }
}
