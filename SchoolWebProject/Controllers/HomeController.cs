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
        public readonly ILogger logger = null;
        private IUnitOfWork unitOfWork;
        private AccountService accountService;

        public HomeController(ILogger tmplogger, AccountService input, IUnitOfWork unit)
        {
            this.logger = tmplogger;
            this.accountService = input;
            this.unitOfWork = unit;
        }

        [Authorize]
        public ActionResult Index()
        {
            Expression<Func<User, bool>> getUser = user => user.LogInData.Login == HttpContext.User.Identity.Name;
            SchoolWebProject.Domain.Models.User currUser = this.unitOfWork.UserRepository.Get(getUser);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
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
            var userData = new
            {
                Id = currUser.Id,
                Role = role.ToString(),
                FirstName = currUser.FirstName,
                MiddleName = currUser.MiddleName,
                LastName = currUser.LastName,
                Address = currUser.Address,
                Email = currUser.Email,
                Image = currUser.Image,
                PhoneNumber = currUser.PhoneNumber
            };
            ViewBag.Links = this.accountService.GetUserRaws(role);
            ViewBag.user = serializer.Serialize(userData);
            return this.View();
        }
    }
}
