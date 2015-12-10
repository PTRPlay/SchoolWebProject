﻿using System;
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
using SchoolWebProject.Services.Models;


namespace SchoolWebProject.Controllers
{
    public class TeacherController : ApiController
    {
        private ILogger logger;

        private TeacherService teacherService;

        private SubjectService subjectService;

        private IAccountService accountService;

        public TeacherController(ILogger logger, TeacherService teacherService, SubjectService subjectService, IAccountService accService) 
        {
            this.logger = logger;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
            this.accountService = accService;
        }

        // GET api/teacher
        public IEnumerable<ViewTeacher> Get()
        {
            var teachers = this.teacherService.GetAllTeachers();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<SchoolWebProject.Domain.Models.Teacher>, IEnumerable<ViewTeacher>>(teachers);
            return viewModel;
        }

        // GET api/teacher/5
        public ViewTeacher Get(int id)
        {
            var teacher = this.teacherService.GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<SchoolWebProject.Domain.Models.Teacher, ViewTeacher>(teacher);
            this.logger.Info("Geting teacher {0}, {1}", teacher.LastName, teacher.FirstName);
            return viewModel;
        }

        public IEnumerable<ViewTeacher> Get(string filter)
        {
            return AutoMapper.Mapper.Map<IEnumerable<SchoolWebProject.Domain.Models.Teacher>, IEnumerable<ViewTeacher>>(this.teacherService.GetByName(filter));
        }

        // POST api/teacher
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]ViewTeacher value)
        {
            SchoolWebProject.Domain.Models.Teacher teacher = AutoMapper.Mapper.Map<ViewTeacher, SchoolWebProject.Domain.Models.Teacher>(value);
            teacher.RoleId = 2;
            if (teacher.Email != null)
                teacher.LogInData = this.accountService.GenerateUserLoginData(teacher);
            this.teacherService.AddTeacher(teacher);
            this.teacherService.SaveTeacher();
            this.logger.Info("Added teacher {0}, {1}", teacher.LastName, teacher.FirstName);
        }

        // PUT api/teacher/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]ViewTeacher value)
        {
            SchoolContext bin = new SchoolContext();
            SchoolWebProject.Domain.Models.Teacher teacher = (SchoolWebProject.Domain.Models.Teacher)bin.Users.First(p => p.Id == value.Id);
            IEnumerable<Subject> subjects = AutoMapper.Mapper.Map<IEnumerable<ViewSubject>, IEnumerable<Subject>>(value.Subjects);
            value.Subjects = null;
            AutoMapper.Mapper.Map<ViewTeacher, SchoolWebProject.Domain.Models.Teacher>(value, teacher);
            foreach (Subject subject in subjects)
            { 
                if (bin.Subjects.First((p) => p.Id == subject.Id) != null)
                {
                    teacher.Subjects.Add(bin.Subjects.First((p) => p.Id==subject.Id));
                }
            }

            bin.SaveChanges();
       }

        // DELETE api/teacher/5
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            //// TO DO
            //// this.teacherService.RemoveTeacher()
            this.logger.Info("Deleted teacher");
        }
    }
}
