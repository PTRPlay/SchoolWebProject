using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Mark
    {
        public int Id { get; set; }

        public int Value { get; set; }

        // public int PupilId { get; set; }

        public virtual Pupil Pupil { get; set; }

        // public int ScheduleId { get; set; }

        // public virtual Schedule Schedule { get; set; }

        public int LessonDetailId { get; set; }

        public virtual LessonDetail LessonDetail { get; set; }

        public int MarkTypeId { get; set; }

        public virtual MarkType MarkType { get; set; }

        public int SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
