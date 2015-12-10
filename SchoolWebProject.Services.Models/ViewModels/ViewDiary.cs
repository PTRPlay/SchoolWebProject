using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Services.Models
{
    class ViewDiary
    {
        public int IdPupil { get; set; }

        public int OrderNumber { get; set; }

        public int DayOfTheWeek { get; set; }

        public string SubjectName { get; set; }

        public string HomeTask { get; set; }

        public string Theme { get; set; }

        public int Value { get; set; }

        public string MarkTypeName { get; set; }
    }
}
