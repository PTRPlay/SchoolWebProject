using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Teacher : User
    {
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }

        public int TeacherCategoryId { get; set; }

        public virtual TeacherCategory TeacherCategory { get; set; }

        public int TeacherDegreeId { get; set; }

        public virtual TeacherDegree TeacherDegree { get; set; }

        public DateTime WorkBegin { get; set; }

        public virtual List<Subject> Subjects { get; set; }

        public virtual List<Schedule> Schedules { get; set; }
    }
}
