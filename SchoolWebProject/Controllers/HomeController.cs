using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using System.Collections;
using System.Runtime.Serialization.Json;
//using simple = SchoolWebProject.Services.Models;

namespace SchoolWebProject.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger logger = null;
        protected GenericRepository<User> repository;
        private AccountService accountService;

        public HomeController(ILogger tmplogger, AccountService input)
        {
            this.logger = new Logger();
            this.repository = new GenericRepository<User>(new DbFactory());
            this.accountService = input;
        }
        
        [Authorize]
        public ActionResult Index()
        {
            Constants.UserRoles role = Constants.UserRoles.None;
            if (HttpContext.User.IsInRole(Constants.UserRoles.Admin.ToString())) role = Constants.UserRoles.Admin;
            else if (HttpContext.User.IsInRole(Constants.UserRoles.Teacher.ToString())) role = Constants.UserRoles.Teacher;
            else if (HttpContext.User.IsInRole(Constants.UserRoles.Pupil.ToString())) role = Constants.UserRoles.Pupil;
            else if (HttpContext.User.IsInRole(Constants.UserRoles.Parent.ToString())) role = Constants.UserRoles.Parent;
            else return this.RedirectToAction("login", "account");
            ViewBag.Links = this.accountService.GetUserRaws(role);
            Expression<Func<User,bool>> getUser = user => user.LogInData.Login == HttpContext.User.Identity.Name;
            User currUser = repository.Get(getUser);
            currUser.LogInData = null;
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string temp = ser.Serialize(currUser);
            
            ViewBag.user = temp;
            return this.View();
        }

    }
}
