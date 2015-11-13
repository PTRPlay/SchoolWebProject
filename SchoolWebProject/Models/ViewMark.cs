﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Models
{
    public class ViewMark
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTime Date { get; set; }

        public int ScheduleId { get; set; }

        public int LessonDetailId { get; set; }

        public int MarkTypeId { get; set; }

        public int SchoolId { get; set; }

     public ViewPupil Pupil { get; set; }

        
    }
}