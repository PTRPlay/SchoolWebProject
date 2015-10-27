using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SchoolWebProject.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger logger = null;

        public HomeController(ILogger tmplogger)
        {
            logger = tmplogger;
        }
        
        public ActionResult Index()
        {
              SchoolContext mdc = new SchoolContext();
           {

               int i = mdc.Schools.Count();
            }

           var teacherCategoriesEntries = (from entry in mdc.TeacherCategories select entry);
           ViewBag.TeacherCategories = teacherCategoriesEntries.ToList();
           var teacherDegreeEntries = (from entry in mdc.TeacherDegrees select entry);
           ViewBag.TeacherDegrees = teacherDegreeEntries.ToList();
           var schoolEntries = (from entry in mdc.Schools select entry);
           ViewBag.Schools = schoolEntries.ToList();
           var teacherEntries = (from entry in mdc.Users select entry);
           ViewBag.Teachers = teacherEntries.ToList();

            logger.ErrorLog("Kolia");
            return View();
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }

    }
}
