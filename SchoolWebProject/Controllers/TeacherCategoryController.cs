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

        private GenericRepository<TeacherCategory> repository;

        private UnitOfWork unitOfWork;
        
        private TeacherCategoryService teacherCategories;

        private TeacherService teachers;

        public TeacherCategoryController(ILogger logger, GenericRepository<TeacherCategory> teacherCategoryRepo, UnitOfWork unitOfWork)
        {
            this.teacherCategoryLogger = logger;
            this.repository = teacherCategoryRepo;
            this.unitOfWork = unitOfWork;
            this.teacherCategories = new TeacherCategoryService(this.teacherCategoryLogger, this.repository, this.unitOfWork);
            this.teachers = new TeacherService(new Logger(), new GenericRepository<Teacher>(new DbFactory()));
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
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Teacher>, IEnumerable<ViewTeacher>>(teachers.GetAllTeachers().Where(c=> c.TeacherCategoryId == id));
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
