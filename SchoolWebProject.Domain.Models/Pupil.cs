using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Pupil : User
    {
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual List<Parent> Parents { get; set; }

        public virtual List<Mark> Marks { get; set; }
    }
}