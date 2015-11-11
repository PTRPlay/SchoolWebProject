using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public class TeacherCategoryService : BaseService, ITeacherCategoryService
    {
        private ILogger teacherCategoryLogger;
        
        private IRepository<TeacherCategory> repository;

        private IUnitOfWork unitOfWork;

        public TeacherCategoryService(ILogger logger)
            : base(logger)
        {
            this.teacherCategoryLogger = logger;
            this.repository = new GenericRepository<TeacherCategory>(new DbFactory());
            this.unitOfWork = new UnitOfWork(new DbFactory());
        }

        public IEnumerable<TeacherCategory> GetAllTeacherCategories()
        {
            return this.repository.GetAll();
        }

        public TeacherCategory GetTeacherCategoryById(int id)
        {
            return this.repository.GetById(id);
        }

        public void UpdateTeacherCategory(TeacherCategory teacherCategory)
        {
            this.repository.Update(teacherCategory);
        }

        public void AddTeacherCategory(TeacherCategory teacherCategory)
        {
            repository.Add(teacherCategory);
        }

        public void RemoveTeacherCategory(TeacherCategory teacherCategory)
        {
            repository.Delete(teacherCategory);
        }

        public void SaveTeacherCategory()
        {
            unitOfWork.SaveChanges();
        }
    }
}
