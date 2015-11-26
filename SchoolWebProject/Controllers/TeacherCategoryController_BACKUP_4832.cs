using System;
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
            logger.Info("Get all teacher categories");
            return viewModel;
        }

        // GET api/teachercategory/5
        public ViewTeacherCategory Get(int id)
        {
            var teacherCategory = this.teacherCategoryService.GetTeacherCategoryById(id);
            var viewModel = AutoMapper.Mapper.Map<TeacherCategory, ViewTeacherCategory>(teacherCategory);
            return viewModel;
<<<<<<< HEAD
=======
            logger.Info("Getted teacher category {0}", teacherCategory.Name);
>>>>>>> 068d3af1c06d736fd1d90911442cfe76667ec17b
        }

        // POST api/teachercategory
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]ViewTeacherCategory value)
        {
            var teacherCategory = AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(value);
            this.teacherCategoryService.AddTeacherCategory(teacherCategory);
            this.teacherCategoryService.SaveTeacherCategory();
            logger.Info("Added new teacher category");
        }

        // PUT api/teachercategory/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]ViewTeacherCategory value)
        {
            var teacherCategory = this.teacherCategoryService.GetTeacherCategoryById(id);
            AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(value, teacherCategory);
<<<<<<< HEAD
            this.teacherCategoryService.UpdateTeacherCategory(teacherCategory);
            this.teacherCategoryService.SaveTeacherCategory();
=======
            teacherCategoryService.UpdateTeacherCategory(teacherCategory);
            teacherCategoryService.SaveTeacherCategory();
            logger.Info("Edited teacher category");
>>>>>>> 068d3af1c06d736fd1d90911442cfe76667ec17b
        }

        // DELETE api/teachercategory/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            this.teacherCategoryService.DeleteTeacherCategory(id);
            this.teacherCategoryService.SaveTeacherCategory();
            logger.Info("Delete teacher category");
        }
    }
}
