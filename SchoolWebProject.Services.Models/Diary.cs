using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Services.Models
{
    public class Diary
    {
        public int IdPupil { get; set; }
        //// public int GroupId { get; set; }
        ////  public int IdSchedule { get; set; }

        public int OrderNumber { get; set; }

        public int DayOfTheWeek { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        //// public int IdLessonDetail { get; set; }

    //    public string HomeTask { get; set; }

    //    public string Theme { get; set; }

        //// public DateTime Date { get; set; }

    //    public int Value { get; set; }

        //// public int MarkTypeId { get; set; }
    //    public string MarkTypeName { get; set; }

    }
}
