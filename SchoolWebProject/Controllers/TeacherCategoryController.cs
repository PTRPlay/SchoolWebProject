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
    public class TeacherCategoryController : ApiController
    {
        private ILogger teacherCategoryLogger;

        private TeacherCategoryService teacherCategoryService;

        public TeacherCategoryController(ILogger logger, TeacherCategoryService teacherCategoryService) 
        {
            this.teacherCategoryLogger = logger;
            this.teacherCategoryService = teacherCategoryService;
        }

        // GET api/teachercategory
        public IEnumerable<ViewTeacherCategory> Get()
        {
            var teacherCategories = teacherCategoryService.GetAllTeacherCategories();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<TeacherCategory>, IEnumerable<ViewTeacherCategory>>(teacherCategories);
            teacherCategoryLogger.Info("Gets Teaceher category");
            return viewModel;
        }

        // GET api/teachercategory/5
        public ViewTeacherCategory Get(int id)
        {
            var teacherCategory = teacherCategoryService.GetTeacherCategoryById(id);
            var viewModel = AutoMapper.Mapper.Map<TeacherCategory, ViewTeacherCategory>(teacherCategory);
            return viewModel;

        }

        // POST api/teachercategory
        public void Post([FromBody]ViewTeacherCategory value)
        {
            TeacherCategory teacherCategory = AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(value);
            this.teacherCategoryService.AddTeacherCategory(teacherCategory);
            this.teacherCategoryService.SaveTeacherCategory();
            
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
