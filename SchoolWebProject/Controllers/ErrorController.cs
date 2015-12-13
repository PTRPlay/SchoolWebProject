using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SchoolWebProject.Controllers
{
    public class ErrorController : Controller
    {
        public readonly ILogger logger;

        public ErrorController(ILogger tmpLogger)
        {
            this.logger = tmpLogger;

        }

        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            logger.Error("Following error occured: {0}", message);
            return View();
        }
    }
}
