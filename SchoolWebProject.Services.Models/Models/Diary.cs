using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Services.Models
{
    public class Diary
    {
        public int IdPupil { get; set; }

        public int OrderNumber { get; set; }

        public int DayOfTheWeek { get; set; }

        public string SubjectName { get; set; }

        public string HomeTask { get; set; }

        public string LessonTheme { get; set; }

        public DateTime Date { get; set; }

        public string MarkValue { get; set; }

        public string MarkTypeName { get; set; }
    }
}