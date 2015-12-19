using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;

namespace SchoolWebProject.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger Logger = null;
        private IUnitOfWork unitOfWork;
        private AccountService accountService;

        public HomeController(ILogger tmplogger, AccountService input, IUnitOfWork unit)
        {
            this.Logger = tmplogger;
            this.accountService = input;
            this.unitOfWork = unit;
        }

        [Authorize]
        public ActionResult Index()
        {
            Constants.UserRoles role = Constants.UserRoles.None;
            if (HttpContext.User.IsInRole(Constants.UserRoles.Admin.ToString()))
            {
                role = Constants.UserRoles.Admin;
            }
            else if (HttpContext.User.IsInRole(Constants.UserRoles.Teacher.ToString()))
            {
                role = Constants.UserRoles.Teacher;
            }
            else if (HttpContext.User.IsInRole(Constants.UserRoles.Pupil.ToString()))
            {
                role = Constants.UserRoles.Pupil;
            }
            else if (HttpContext.User.IsInRole(Constants.UserRoles.Parent.ToString()))
            {
                role = Constants.UserRoles.Parent;
            }
            else return this.RedirectToAction("login", "account");
            User currUser = this.accountService.GetCurrentUserProfile(HttpContext.User.Identity.Name);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var mainUserData = new
            {
                Id = currUser.Id,
                Role = role.ToString()
            };
            ViewBag.Links = this.accountService.GetUserRaws(role);
            ViewBag.mainUserData = serializer.Serialize(mainUserData); 
            return this.View();
        }
    }
}
