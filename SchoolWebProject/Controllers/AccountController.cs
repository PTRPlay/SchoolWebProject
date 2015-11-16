using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;

namespace SchoolWebProject.Controllers
{
    public class AccountController : Controller
    {
        public readonly ILogger logger = null;
        private AccountService accountService;

        public AccountController(ILogger tmplogger, AccountService accService)
        {
            this.logger = tmplogger;
            this.accountService = accService;
        }

        public ActionResult LogIn(string error = "")
        {
            ViewBag.error = error;
            return this.View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(string userName, string password)
        {
            User currentUser = this.accountService.GetUser(userName, password);
            if (currentUser == null)
            {
                string error = "Wrong login data!";
                return this.LogIn(error);
            }
            this.CreateCookie(currentUser);
            return this.RedirectToAction("Index","Home");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("LogIn");
        }

        private void CreateCookie(User currentUser)
        {
            int minutesToCookiesExpirate = 20;
            LogInData currLogin = this.accountService.GetUserLogInData(currentUser.Id);
            string currentUserRole = this.accountService.GetRoleById(currentUser.RoleId).Name;

            // parameter "name" - "login" string or "first name" string? 
            FormsAuthenticationTicket authorizationTicket = new FormsAuthenticationTicket(1, currLogin.Login,
                DateTime.Now, DateTime.Now.AddMinutes(minutesToCookiesExpirate), true, currentUserRole);
            string encryptedTicket = FormsAuthentication.Encrypt(authorizationTicket);
            HttpCookie authorizationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authorizationCookie);
        }
    }
}
