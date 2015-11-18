using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services.Models
{
    public class ViewJournal
    {
        public IEnumerable<ViewPupil> Pupils { get; set; }

        public IEnumerable<ViewMark> Marks { get; set; }

        public IEnumerable<ViewLessonDetail> LessonDetails { get; set; }
    }
}