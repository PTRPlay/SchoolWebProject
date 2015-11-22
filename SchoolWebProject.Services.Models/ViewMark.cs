using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Services.Models
{
    public class ViewMark
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int ScheduleId { get; set; }

        public int LessonDetailId { get; set; }

        public int MarkTypeId { get; set; }

        public int SchoolId { get; set; }

        public ViewLessonDetail LessonDetail { get; set; }

        public int PupilId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        
    }
}