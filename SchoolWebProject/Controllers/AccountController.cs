﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using UnidecodeSharpFork;

namespace SchoolWebProject.Controllers
{
    public class AccountController : Controller
    {
        public readonly ILogger Logger = null;
        private IAccountService accountService;

        public AccountController(ILogger tmplogger, IAccountService accService)
        {
            this.Logger = tmplogger;
            this.accountService = accService;
        }

        public ActionResult LogIn(string error = "")
        {
            ViewBag.error = error;
            return this.View("login");
        }

        [HttpPost]
        public ActionResult LogIn(string userName, string password)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return this.RedirectToAction("logout", "account");
            User currentUser = this.accountService.GetUser(userName, password);
            if (currentUser == null)
            {
                string error = Constants.LoginError;
                return this.LogIn(error);
            }

            this.CreateCookie(currentUser);
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("login");
        }

        private void CreateCookie(User currentUser)
        {
            LogInData currLogin = this.accountService.GetUserLogInData(currentUser.Id);
            string currentUserRole = this.accountService.GetRoleById(currentUser.RoleId).Name;
            FormsAuthenticationTicket authorizationTicket = new FormsAuthenticationTicket(1, currLogin.Login,
                DateTime.Now, DateTime.Now.AddMinutes(Constants.MinutesToCookiesExpirate), true, currentUserRole);
            string encryptedTicket = FormsAuthentication.Encrypt(authorizationTicket);
            HttpCookie authorizationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authorizationCookie);
        }
    }
}
