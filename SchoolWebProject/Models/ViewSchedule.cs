﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Models
{
    public class ViewSchedule
    {
        //public int Id { get; set; }

        public ViewSubject Subject { get; set; }

        public ViewTeacher Teacher { get; set; }

        public int OrderNumber { get; set; }

        public int DayOfTheWeek { get; set; }

        public string Group { get; set; }
        
        public string ClassRoom { get; set; }

        //public virtual IEnumerable<LessonDetail> LessonsDetails { get; set; }
    }
}