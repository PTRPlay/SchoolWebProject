using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;

namespace SchoolWebProject.Controllers
{
    public class TeacherController : ApiController
    {
        private ILogger logger;

        private TeacherService teacherService;

        private SubjectService subjectService;

        private IAccountService accountService;

        public TeacherController(ILogger Logger, TeacherService teacherService, SubjectService subjectService, IAccountService accService) 
        {
            this.logger = Logger;
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
            logger.Info("Geting teacher {0}, {1}", teacher.LastName, teacher.FirstName);
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
            logger.Info("Added teacher {0}, {1}", teacher.LastName, teacher.FirstName);
        }

        // PUT api/teacher/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]ViewTeacher value)
        {
            var teacher = this.teacherService.GetProfileById(id);
            AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value, (Teacher)teacher);
            this.teacherService.UpdateProfile(teacher);
            logger.Info("Edited teacher {0}, {1}", teacher.LastName, teacher.FirstName);
       }

        // DELETE api/teacher/5
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            //// TO DO
            //// this.teacherService.RemoveTeacher()
            logger.Info("Deleted teacher");
        }
    }
}
