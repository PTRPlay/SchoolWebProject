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

namespace SchoolWebProject.Controllers
{
    public class SchoolsController : BaseApiController
    {
        private ISchoolService schoolService;

        public SchoolsController(ILogger logger, ISchoolService pupilService) : base(logger) 
        {
            this.schoolService = pupilService;
        }

        // GET api/schools
        public IEnumerable<ViewSchool> Get()
        {
            var schools = this.schoolService.GetAllSchools();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<School>, IEnumerable<ViewSchool>>(schools);
            return viewModel;
        }

        // GET api/schools/5
        public ViewSchool Get(int id)
        {
            var school = this.schoolService.GetSchoolById(id);
            var viewModel = AutoMapper.Mapper.Map<School, ViewSchool>(school);
            return viewModel;
        }

        // POST api/schools
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/schools/5
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/schools/5
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
        }
    }
}
