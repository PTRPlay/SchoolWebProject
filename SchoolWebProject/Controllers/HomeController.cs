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

           var aboutTeacherEntries = (from entry in mdc.TeacherCategories select entry);
           ViewBag.TeacherCategories = aboutTeacherEntries.ToList();

            logger.ErrorLog("Kolia");
            return View();
        }

    }
}
