using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
//using simple = SchoolWebProject.Services.Models;

namespace SchoolWebProject.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger logger = null;
        protected GenericRepository<Teacher> repository;

        public HomeController(ILogger tmplogger)
        {
            this.logger = new Logger();
            this.repository = new GenericRepository<Teacher>(new DbFactory());
        }
        
        public ActionResult Index()
        {
<<<<<<< HEAD
              SchoolContext mdc = new SchoolContext();
<<<<<<< HEAD


           var teacherCategoriesEntries = from entry in mdc.TeacherCategories select entry;
=======
           //{
           //    int i = mdc.Schools.Count();
           // }
           //simple.Teacher t = simple.Teacher.CreateSimpleTeacher(mdc.Users.FirstOrDefault(u => u.Id == 13) as Teacher);
           simple.Pupil p = simple.Pupil.CreateSimplePupil(mdc.Users.FirstOrDefault(u => u.Id == 50) as Pupil);
            var teacherCategoriesEntries = from entry in mdc.TeacherCategories select entry;
>>>>>>> 6cbb462dd287b01d260ba7bcd93ba068bcac2345
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
            
=======
            //using (var mdc = new SchoolContext())
            //{
                SchoolContext mdc = new SchoolContext();
                //{
                //    int i = mdc.Schools.Count();
                // }
                //simple.Teacher t = simple.Teacher.CreateSimpleTeacher(mdc.Users.FirstOrDefault(u => u.Id == 13) as Teacher);
                //simple.Pupil p = simple.Pupil.CreateSimplePupil(mdc.Users.FirstOrDefault(u => u.Id == 50) as Pupil);
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
            //}
>>>>>>> 6f82f1eb14c683198fa2abf6dab902a332c1e5c7
            this.logger.Debug("Kolia");
            return this.View();
        }

<<<<<<< HEAD

=======
        //[HttpGet]
        //public string GetTeachers()
        //{
        //    var item = new SchoolContext().Roles.First(i => i.Id == 2);
        //    List<string> teachers = new List<string>();
        //    foreach (var i in item.Users)
        //    {
        //        var teacherCategoriesEntries = from entry in mdc.TeacherCategories select entry;
        //        ViewBag.TeacherCategories = teacherCategoriesEntries.ToList();
        //        var teacherDegreeEntries = from entry in mdc.TeacherDegrees select entry;
        //        ViewBag.TeacherDegrees = teacherDegreeEntries.ToList();
        //        var subjectEntries = from entry in mdc.Subjects select entry;
        //        ViewBag.Subjects = subjectEntries.ToList();
        //        var schoolEntries = from entry in mdc.Schools select entry;
        //        ViewBag.Schools = schoolEntries.ToList();
        //        var teacherEntries = from entry in mdc.Users where entry.RoleId == 2 select entry;
        //        ViewBag.Teachers = teacherEntries.ToList();
        //        var pupilEntries = from entry in mdc.Users where entry.RoleId == 3 select entry;
        //        ViewBag.Pupils = pupilEntries.ToList();
        //        var announcementEntries = from entry in mdc.Announcements select entry;
        //        ViewBag.Announcements = announcementEntries.ToList();
        //    }
        //    this.logger.Debug("Kolia");
        //    return this.View();
        //}
>>>>>>> 6f82f1eb14c683198fa2abf6dab902a332c1e5c7
    }
}
