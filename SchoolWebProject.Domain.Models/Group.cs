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
        [MaxLength(20)]
        public string Name { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public virtual List<Pupil> Pupils { get; set; }
        public virtual List<Schedule> Schedules { get; set; }

        public Group()
        {

        }
    }
}
