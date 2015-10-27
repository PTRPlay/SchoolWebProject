using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            return this.View();
        }

        [HttpPost]
        public User LogIn(string userName, string password, bool rememberMe)
        {
            // compare input username and password with database users login info
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Home");
        }

        private string GetHashedPassword(string password)
        {
            // current user must be taken from AccountService
            string passwordPlusSalt = string.Format(password + "current user's salt");

            // transform input string to byte[]
            byte[] bytePassword = new byte[password.Length * sizeof(char)];
            System.Buffer.BlockCopy(password.ToCharArray(), 0, bytePassword, 0, bytePassword.Length);

            // hashing
            byte[] hashedPassword = SHA256.Create().ComputeHash(bytePassword);

            // tranform hashed password from byte[] to string
            char[] tempChars = new char[hashedPassword.Length / sizeof(char)];
            System.Buffer.BlockCopy(hashedPassword, 0, tempChars, 0, hashedPassword.Length);
            return new string(tempChars);
        }

        // get salt from database
        private string GetSalt(User currentUser)
        {
            throw new NotImplementedException();
        }
    }
}
