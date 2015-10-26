using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class MarkType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Mark> Marks { get; set; }
    }
}
