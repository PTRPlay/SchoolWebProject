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
using System.Web;

namespace SchoolWebProject.Controllers
{
    public class TeacherController : ApiController
    {
        
        private ILogger getLogger;

        private TeacherService teachers;

        public TeacherController(ILogger logger) 
        {
            this.getLogger = logger;
            this.teachers = new TeacherService(this.getLogger);
        }
        // GET api/teacher
        public IEnumerable<ViewTeacher> Get()
        {
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Teacher>,IEnumerable<ViewTeacher>>(teachers.GetAllTeachers());
            return viewModel;
        }

        // GET api/teacher/5
        public ViewTeacher Get(int id)
        {
            var viewModel = AutoMapper.Mapper.Map<Teacher, ViewTeacher>(teachers.GetProfileById(id));
            return viewModel;
        }

        // POST api/teacher
        public void Post([FromBody]ViewTeacher value)
        {
            var teacher = AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value);
            new TeacherService(this.getLogger).AddTeacher(teacher);
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
