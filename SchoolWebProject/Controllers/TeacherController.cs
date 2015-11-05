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
            var teachers = new TeacherService(new SerilogLogger(),
                            new GenericRepository<Teacher>(new DbFactory()))
                           .GetAllTeachers();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Teacher>,IEnumerable<ViewTeacher>>(teachers);
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
            var teacher = AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value);
            new TeacherService(new SerilogLogger(),
                                new GenericRepository<Teacher>(new DbFactory()))
                                .AddTeacher(teacher);
            var db = new SchoolContext();
            db.Users.Add(teacher);
            db.SaveChanges();
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
