using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Parent : User
    {
        public virtual List<Pupil> Pupils { get; set; }
    }
}
