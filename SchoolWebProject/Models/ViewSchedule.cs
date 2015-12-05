using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Models
{
    public class ViewSchedule
    {
        public int Id { get; set; }

        public ViewSubject Subject { get; set; }

        public ViewTeacher Teacher { get; set; }

        public int OrderNumber { get; set; }

        public int DayOfTheWeek { get; set; }

        public int ClassRoomId { get; set; }

        //public virtual IEnumerable<LessonDetail> LessonsDetails { get; set; }
    }
}