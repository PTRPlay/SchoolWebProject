using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public int NameNumber { get; set; }

        [Required]
        [MaxLength(2)]
        public string NameLetter { get; set; }

        public int SchoolId { get; set; }

        public virtual School School { get; set; }

        public virtual List<Teacher> Teacher { get; set; }
        
        public virtual List<Pupil> Pupils { get; set; }

        public virtual List<Schedule> Schedules { get; set; }
    }
}
