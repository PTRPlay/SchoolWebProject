using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Services
{
    public class TeacherCategoryService : BaseService, ITeacherCategoryService
    {
        private IUnitOfWork unitOfWork;

        public TeacherCategoryService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddTeacherCategory (TeacherCategory teacherCategory)
        {
            this.unitOfWork.TeacherCategoryRepository.Add(teacherCategory);
            this.SaveTeacherCategory();
        }

        public IEnumerable<TeacherCategory> GetAllTeacherCategories()
        {
            return this.unitOfWork.TeacherCategoryRepository.GetAll();
        }

        public void DeleteTeacherCategory(int id)
        {
            TeacherCategory teacherCategory = this.unitOfWork.TeacherCategoryRepository.GetById(id);
            teacherCategory.Teachers.RemoveAll(category => teacherCategory.Id == id);
            this.unitOfWork.TeacherCategoryRepository.Delete(teacherCategory);
            this.SaveTeacherCategory();
        }

        public TeacherCategory GetTeacherCategoryById(int id)
        {
            return this.unitOfWork.TeacherCategoryRepository.GetById(id);
        }

        public void UpdateTeacherCategory(TeacherCategory teacherCategory)
        {
            this.unitOfWork.TeacherCategoryRepository.Update(teacherCategory);
            this.SaveTeacherCategory();
        }

        public void SaveTeacherCategory()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
