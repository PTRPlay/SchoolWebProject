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
using SchoolWebProject.Services.Models;


namespace SchoolWebProject.Controllers
{
    public class TeacherCategoryController : BaseApiController
    {
        private TeacherCategoryService teacherCategoryService;

        public TeacherCategoryController(ILogger logger, TeacherCategoryService teacherCategoryService) : base(logger) 
        {
            this.teacherCategoryService = teacherCategoryService;
        }

        // GET api/teachercategory
        public IEnumerable<ViewTeacherCategory> Get()
        {
            var teacherCategories = this.teacherCategoryService.GetAllTeacherCategories();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<TeacherCategory>, IEnumerable<ViewTeacherCategory>>(teacherCategories);
            return viewModel;
        }

        // GET api/teachercategory/5
        public ViewTeacherCategory Get(int id)
        {
            var teacherCategory = this.teacherCategoryService.GetTeacherCategoryById(id);
            var viewModel = AutoMapper.Mapper.Map<TeacherCategory, ViewTeacherCategory>(teacherCategory);
            logger.Info("Getted teacher category {0}", teacherCategory.Name);
            return viewModel;
        }

        // POST api/teachercategory
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]ViewTeacherCategory value)
        {
            var teacherCategory = AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(value);
            this.teacherCategoryService.AddTeacherCategory(teacherCategory);
            logger.Info("Added new teacher category");
        }

        // PUT api/teachercategory/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]ViewTeacherCategory value)
        {
            var teacherCategory = this.teacherCategoryService.GetTeacherCategoryById(id);
            AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(value, teacherCategory);
            this.teacherCategoryService.UpdateTeacherCategory(teacherCategory);
            logger.Info("Edited teacher category");
        }

        // DELETE api/teachercategory/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            this.teacherCategoryService.DeleteTeacherCategory(id);
            logger.Info("Delete teacher category");
        }
    }
}
