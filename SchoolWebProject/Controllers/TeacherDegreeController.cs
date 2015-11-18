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
using SchoolWebProject.Models;

namespace SchoolWebProject.Controllers
{
    public class TeacherDegreeController : BaseApiController
    {
        private GenericRepository<TeacherDegree> repository;

        private TeacherService teachers;

        public TeacherDegreeController(ILogger logger, GenericRepository<TeacherDegree> teacherDegreeRepo): base(logger)
        {
            this.repository = teacherDegreeRepo;
            //this.teachers = new TeacherDegreeService(this.teacherDegreeLogger, this.repository);
        }

        // GET api/teacherdegree
        public IEnumerable<ViewTeacherDegree> Get()
        {
            var degree = new SchoolContext().TeacherDegrees;
            var viewDegree = AutoMapper.Mapper.Map<IEnumerable<TeacherDegree>, IEnumerable<ViewTeacherDegree>>(degree);
            logger.Info("Get teacher degree");
            return viewDegree;
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
