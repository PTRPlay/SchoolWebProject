using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class LessonDetail
    {
        public int Id { get; set; }

        public string HomeTask { get; set; }

        public string Theme { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        public virtual Schedule Schedule { get; set; }

        public int SchoolId { get; set; }

        public virtual School School { get; set; }

        public virtual List<Mark> Marks { get; set; }
    }
}
