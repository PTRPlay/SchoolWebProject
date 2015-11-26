using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Data.Entity;
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
        private ILogger getLogger;

        private TeacherService teacherService;
        private SubjectService subjectService;
        private IAccountService accountService;

        public TeacherController(ILogger logger, TeacherService teacherService, SubjectService subjectService, IAccountService accService) 
        {
            this.getLogger = logger;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
            this.accountService = accService;
        }
        // GET api/teacher
        public IEnumerable<ViewTeacher> Get()
        {
            var teachers = this.teacherService.GetAllTeachers();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Teacher>, IEnumerable<ViewTeacher>>(teachers);
            return viewModel;
        }

        // GET api/teacher/5
        public ViewTeacher Get(int id)
        {
            var teacher = this.teacherService.GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<Teacher, ViewTeacher>(teacher);
            return viewModel;
        }

        public IEnumerable<ViewTeacher> Get(string filter)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Teacher>, IEnumerable<ViewTeacher>>(this.teacherService.GetByName(filter));
        }

        // POST api/teacher
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]ViewTeacher value)
        {
            Teacher teacher = AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value);
            teacher.RoleId = 2;
            if (teacher.Email != null)
                teacher.LogInData = this.accountService.GenerateUserLoginData(teacher);
            this.teacherService.AddTeacher(teacher);
            this.teacherService.SaveTeacher();
        }

        // PUT api/teacher/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]ViewTeacher value)
        {
            var teacher = this.teacherService.GetProfileById(id);
            AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value, (Teacher)teacher);
            this.teacherService.UpdateProfile(teacher);
       }

        // DELETE api/teacher/5
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {  
        }
    }
}
