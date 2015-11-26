using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public int OrderNumber { get; set; }

        [Required]
        public int DayOfTheWeek { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        [Required]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public int ClassRoomId { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public virtual List<LessonDetail> LessonsDetails { get; set; }        
    }
}
