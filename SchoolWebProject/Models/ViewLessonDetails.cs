using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Models
{
    public class ViewLessonDetail
    {
        public int Id { get; set; }

        public string HomeTask { get; set; }

        public string Theme { get; set; }

        public DateTime Date { get; set; }
    }
}