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
           {
               int i = mdc.Schools.Count();
            }

           var teacherCategoriesEntries = from entry in mdc.TeacherCategories select entry;
           ViewBag.TeacherCategories = teacherCategoriesEntries.ToList();
           var teacherDegreeEntries = from entry in mdc.TeacherDegrees select entry;
           ViewBag.TeacherDegrees = teacherDegreeEntries.ToList();
<<<<<<< HEAD
           var subjectEntries = from entry in mdc.Subjects select entry;
           ViewBag.Subjects = subjectEntries.ToList();
=======
>>>>>>> 58f4819d3e4d3382619061ab5412f80984b8b09b
           var schoolEntries = from entry in mdc.Schools select entry;
           ViewBag.Schools = schoolEntries.ToList();
           var teacherEntries = from entry in mdc.Users select entry;
           ViewBag.Teachers = teacherEntries.ToList();
<<<<<<< HEAD
           var announcementEntries = from entry in mdc.Announcements select entry;
           ViewBag.Announcements = announcementEntries.ToList();
            
            logger.ErrorLog("Kolia");
            return View();
=======

            this.logger.ErrorLog("Kolia");
            return this.View();
>>>>>>> 58f4819d3e4d3382619061ab5412f80984b8b09b
        }
    }
}
