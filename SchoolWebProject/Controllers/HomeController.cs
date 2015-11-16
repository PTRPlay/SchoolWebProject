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
using System.Collections;
//using simple = SchoolWebProject.Services.Models;

namespace SchoolWebProject.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger logger = null;
        protected GenericRepository<Teacher> repository;
        private AccountService accountService;

        public HomeController(ILogger tmplogger, AccountService input)
        {
            this.logger = new Logger();
            this.repository = new GenericRepository<Teacher>(new DbFactory());
            this.accountService = input;
        }
        
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                Constants.UserRoles role = Constants.UserRoles.None;
                if (HttpContext.User.IsInRole(Constants.UserRoles.Admin.ToString())) role = Constants.UserRoles.Admin;
                else if (HttpContext.User.IsInRole(Constants.UserRoles.Teacher.ToString())) role = Constants.UserRoles.Teacher;
                else if (HttpContext.User.IsInRole(Constants.UserRoles.Pupil.ToString())) role = Constants.UserRoles.Pupil;
                else if (HttpContext.User.IsInRole(Constants.UserRoles.Parent.ToString())) role = Constants.UserRoles.Parent;
                else return this.RedirectToAction("LogIn", "account");
                ViewBag.Links = this.accountService.GetUserRaws(role);
            }
            else return this.RedirectToAction("LogIn", "account");
            this.logger.Debug("logTest");
            return this.View();
        }

    }
}
