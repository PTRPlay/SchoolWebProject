using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;


namespace SchoolWebProject.Controllers
{
    public class TeacherDegreeController : ApiController
    {
        private ILogger teacherDegreeLogger;

        private GenericRepository<TeacherDegree> repository;

        private TeacherService teachers;

        public TeacherDegreeController(ILogger logger, GenericRepository<TeacherDegree> teacherDegreeRepo)
        {
            this.teacherDegreeLogger = logger;
            this.repository = teacherDegreeRepo;
            //this.teachers = new TeacherDegreeService(this.teacherDegreeLogger, this.repository);
        }

        // GET api/teacherdegree
        public IEnumerable<string> Get()
        {
            var degrees = new SchoolContext().TeacherDegrees;
            var degreeNames = from entry in degrees select entry.Name;
            return degreeNames;
        }

        // GET api/teacherdegree/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/teacherdegree
        public void Post([FromBody]string value)
        {
        }

        // PUT api/teacherdegree/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teacherdegree/5
        public void Delete(int id)
        {
        }
    }
}
