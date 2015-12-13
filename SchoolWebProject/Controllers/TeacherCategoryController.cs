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
            logger.Info("Get all teacher categories");
            return this.teacherCategoryService.GetAllTeacherCategories();
        }

        // GET api/teachercategory/5
        public ViewTeacherCategory Get(int id)
        {
            var teacherCategory = this.teacherCategoryService.GetTeacherCategoryById(id);
            logger.Info("Getted teacher category {0}", teacherCategory.Name);
            return teacherCategory;
        }

        // POST api/teachercategory
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]ViewTeacherCategory value)
        {
            this.teacherCategoryService.AddTeacherCategory(value);
            logger.Info("Added new teacher category");
        }

        // PUT api/teachercategory/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]ViewTeacherCategory value)
        {
            this.teacherCategoryService.UpdateTeacherCategory(id, value);
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
