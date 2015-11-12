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

        private TeacherService teacherService;

        public TeacherController(ILogger logger, TeacherService teacherService) 
        {
            this.getLogger = logger;
            this.teacherService = teacherService;
        }
        // GET api/teacher
        public IEnumerable<ViewTeacher> Get()
        {
            var teachers = teacherService.GetAllTeachers();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Teacher>,IEnumerable<ViewTeacher>>(teachers);
            return viewModel;
        }

        // GET api/teacher/5
        public ViewTeacher Get(int id)
        {
            var teacher = teacherService.GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<Teacher, ViewTeacher>(teacher);
            return viewModel;
        }

        // POST api/teacher
        public void Post([FromBody]ViewTeacher value)
        {
            var teacher = new Teacher();
            AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value,teacher);
            var bin = new SchoolContext();
            bin.Users.Add(teacher);
            bin.SaveChanges();
            //teacherService.AddTeacher(teacher);
        }

        // PUT api/teacher/5
        [HttpPost]
        public void Put(int id, [FromBody]ViewTeacher value)
        {
            var bin = new SchoolContext();
            var teacher = bin.Users.First(p => p.Id == value.Id);
            AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value,(Teacher)teacher);
            //bin.Users.Attach(teacher);
            bin.Entry(teacher).State = System.Data.Entity.EntityState.Modified; 
            bin.SaveChanges();
            //teacherService.UpdateProfile(teacher);
        }

        // DELETE api/teacher/5
        public void Delete(int id)
        {
        }
    }
}
