using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Services.Interfaces;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Data.Infrastructure;


namespace SchoolWebProject.Controllers
{
    public class ErrorController : BaseApiController
    {
        public ErrorController(ILogger logger):base(logger)
        {

        }


    [HttpPost]
        public void Post(ErrorObject value)
        {
            logger.Error("Unhandled exception in Angular application occured. Message: {0} caused by: {1}", value.Exception, value.Cause); 

        }

    [HttpPut]
        public void Put([FromBody]object value)
        {
            logger.Error("Error occured. Message: {0}", value);
        }
    }
}
