using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SchoolWebProject.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger logger = null;

        public HomeController(ILogger tmplogger)
        {
            logger = tmplogger;
        }
        
        public ActionResult Index()
        {
            logger.ErrorLog("Kolia");
            return View();
        }

    }
}
