using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Models;
using AutoMapper;

namespace SchoolWebProject.Controllers
{
    public class TeacherController : ApiController
    {
        // GET api/teacher
        public IEnumerable<ViewTeacher> Get()
        {
            var user = new SchoolContext().Users;
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<User>,IEnumerable<ViewTeacher>>(user);
            return viewModel;
        }

        // GET api/teacher/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/teacher
        public void Post([FromBody]ViewTeacher value)
        {
            var teacher = AutoMapper.Mapper.Map<ViewTeacher, User>(value);
            new SchoolContext().Users.Add(teacher);

        }

        // PUT api/teacher/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teacher/5
        public void Delete(int id)
        {
        }
    }
}
