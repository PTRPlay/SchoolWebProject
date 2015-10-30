using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger logger = null;

        public HomeController(ILogger tmplogger)
        {
            this.logger = tmplogger;
        }
        
        public ActionResult Index()
        {
              SchoolContext mdc = new SchoolContext();
           //{
           //    int i = mdc.Schools.Count();
           // }

           var teacherCategoriesEntries = from entry in mdc.TeacherCategories select entry;
           ViewBag.TeacherCategories = teacherCategoriesEntries.ToList();
           var teacherDegreeEntries = from entry in mdc.TeacherDegrees select entry;
           ViewBag.TeacherDegrees = teacherDegreeEntries.ToList();
           var subjectEntries = from entry in mdc.Subjects select entry;
           ViewBag.Subjects = subjectEntries.ToList();
           var schoolEntries = from entry in mdc.Schools select entry;
           ViewBag.Schools = schoolEntries.ToList();
           var teacherEntries = from entry in mdc.Users where entry.RoleId == 2 select entry;
           ViewBag.Teachers = teacherEntries.ToList();
           var pupilEntries = from entry in mdc.Users where entry.RoleId == 3 select entry;
           ViewBag.Pupils = pupilEntries.ToList();
           var announcementEntries = from entry in mdc.Announcements select entry;
           ViewBag.Announcements = announcementEntries.ToList();
            
            this.logger.Debug("Kolia");
            return this.View();
        }

        public ActionResult GetTeachers()
        {
            //This should be done by services but repository is not done yet 
            var bin = new SchoolContext().Users;
            ViewBag.Teachers = from entry in bin select entry.FirstName+" "+entry.LastName;
            return PartialView();
        }
    }
}
