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
        
        protected SerilogLogger getLogger;
        protected GenericRepository<Teacher> repository;

        public TeacherController() 
        {
            this.getLogger = new SerilogLogger();
            this.repository = new GenericRepository<Teacher>(new DbFactory());
        }
        // GET api/teacher
        public IEnumerable<ViewTeacher> Get()
        {
            var teachers = new TeacherService(this.getLogger,this.repository).GetAllTeachers();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Teacher>,IEnumerable<ViewTeacher>>(teachers);
            return viewModel;
        }

        // GET api/teacher/5
        public ViewTeacher Get(int id)
        {
            TeacherService teachers = new TeacherService(this.getLogger, this.repository);
            var teacher = new TeacherService(this.getLogger, this.repository).GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<Teacher, ViewTeacher>(teacher);
            return viewModel;
        }

        // POST api/teacher
        public void Post([FromBody]ViewTeacher value)
        {
            var teacher = AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value);
            new TeacherService(this.getLogger, this.repository).AddTeacher(teacher);
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
