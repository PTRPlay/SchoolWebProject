using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;

namespace SchoolWebProject.Controllers
{
    public class TeachersController : ApiController
    {
        protected Logger getLogger;
        protected GenericRepository<Teacher> repository;

        public TeachersController() 
        {
            this.getLogger = new Logger();
            this.repository = new GenericRepository<Teacher>(new DbFactory());
        }
        // GET api/teachers
 
        public IEnumerable<Teacher> Get()
        {
            var temp = new TeacherService(this.getLogger, this.repository);

            return temp.GetAllTeachers();
        }

        // GET api/teachers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/teachers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/teachers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teachers/5
        public void Delete(int id)
        {
        }
    }
}
