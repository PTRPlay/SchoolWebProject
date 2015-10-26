using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Parent:User
    {
        public virtual ICollection<Pupil> Pupils { get; set; }

        public Parent()
        {
            Pupils = new HashSet<Pupil>();
        }
    }
}
