using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;

namespace SchoolWebProject.Controllers
{
    public class SubjectsController : ApiController
    {
        private ILogger subjectLogger;

        private SubjectService subjects;

        public SubjectsController(ILogger logger, SubjectService subjects)
        {
            this.subjectLogger = logger;
            this.subjects = subjects;
        }

        // GET api/subject
        public IEnumerable<ViewSubject> Get()
        {
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Subject>, IEnumerable<ViewSubject>>(subjects.GetAllSubject());
            return viewModel;
        }

/*        public IEnumerable<string> Get()
        {
            var subjects = new SchoolContext().Subjects;
            var subjectsName = from entry in subjects select entry.Name;
            return subjectsName;
        }
*/
        // GET api/subjects/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/subjects
        public void Post([FromBody]string value)
        {
        }

        // PUT api/subjects/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/subjects/5
        public void Delete(int id)
        {
        }
    }
}
