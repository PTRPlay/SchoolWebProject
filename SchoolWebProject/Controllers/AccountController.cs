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

        public ActionResult LogIn()
        {
            return this.View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(string userName, string password)
        {
            User currentUser = this.accountService.GetUser(userName, password);
            if (currentUser == null)
            {
                logger.Info("Wrong login data!");
                return this.View("LogIn");
            }
            this.CreateCookie(currentUser);
            switch (currentUser.Role.Name)
            {
                case "admin":
                    // return admin page
                    break;
                case "teacher":
                    // return teacher page
                    break;
                case "pupil":
                    // return pupil page
                    break;
                case "parent":
                    //return parent page
                    break;
            }
            return View("LogIn");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Home");
        }

        private void CreateCookie(User currentUser)
        {
            int minutesToCookiesExpirate = 20;

            // parameter "name" - "login" string or "first name" string?
            FormsAuthenticationTicket authorizationTicket = new FormsAuthenticationTicket(1, currentUser.LogInData.Login,
                DateTime.Now, DateTime.Now.AddMinutes(minutesToCookiesExpirate), true, currentUser.Role.Name);
            string encryptedTicket = FormsAuthentication.Encrypt(authorizationTicket);
            HttpCookie authorizationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authorizationCookie);
        }
    }
}
