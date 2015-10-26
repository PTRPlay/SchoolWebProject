using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolWebProject.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            SchoolContext mdc = new SchoolContext();
            {

                int i = mdc.Schools.Count();

            }
            return View();
        }

    }
}
