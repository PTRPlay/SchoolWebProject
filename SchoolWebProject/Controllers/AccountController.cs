using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        public User LogIn(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string GetHashedPassword(string password)
        {
            throw new NotImplementedException();
            if (Request.Form["submitbutton1"] != null)
            {
                // Code for function 1
            }
        }

        public string GenerateSalt()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }
    }
}
