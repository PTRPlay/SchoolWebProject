using System;
using System.Web.Http;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Controllers
{
    public class BaseApiController : ApiController
    {
        protected ILogger logger;

        public BaseApiController(ILogger logger)
        {
            this.logger = logger;
        }
    }
}