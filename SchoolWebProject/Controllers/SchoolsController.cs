using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;


namespace SchoolWebProject.Controllers
{
    public class SchoolsController : BaseApiController
    {
        private ISchoolService schoolService;

        public SchoolsController(ILogger logger, ISchoolService schoolService) : base(logger) 
        {
            this.schoolService = schoolService;
        }

        // GET api/schools
        public IEnumerable<ViewSchool> Get()
        {
            var view = this.schoolService.GetAllSchools();
            return view;
        }

        // GET api/schools/5
        public ViewSchool Get(int id)
        {
            return this.schoolService.GetSchoolById(id);
        }
    }
}
