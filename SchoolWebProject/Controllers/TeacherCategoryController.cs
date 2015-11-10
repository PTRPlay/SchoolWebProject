﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;

namespace SchoolWebProject.Controllers
{
    public class TeacherCategoryController : ApiController
    {
        private ILogger teacherCategoryLogger;

        private TeacherCategoryService teacherCategories;

        private TeacherService teachers;

        public TeacherCategoryController(ILogger logger)
        {
            this.teacherCategoryLogger = logger;
            this.teacherCategories = new TeacherCategoryService(this.teacherCategoryLogger);
            this.teachers = new TeacherService(new Logger());
        }

        // GET api/teachercategory
        public IEnumerable<ViewTeacherCategory> Get()
        {
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<TeacherCategory>, IEnumerable<ViewTeacherCategory>>(teacherCategories.GetAllTeacherCategories());
            return viewModel;
        }

        // GET api/teachercategory/5
        public IEnumerable<ViewTeacher> Get(int id)
        {
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Teacher>, IEnumerable<ViewTeacher>>(teachers.GetAllTeachersByCategory(id));
            return viewModel;

        }

        // POST api/teachercategory
        public void Post([FromBody]string result)
        {
            var bin = result;
        }

        // PUT api/teachercategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teachercategory/5
        public void Delete(int id)
        {
        }
    }
}
