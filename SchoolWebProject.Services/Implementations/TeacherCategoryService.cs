using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services.Models;

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

        public void AddTeacherCategory (ViewTeacherCategory value)
        {
            var teacherCategory = AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(value);
            this.unitOfWork.TeacherCategoryRepository.Add(teacherCategory);
            this.SaveTeacherCategory();
        }

        public IEnumerable<ViewTeacherCategory> GetAllTeacherCategories()
        {
            var teacherCategories = this.unitOfWork.TeacherCategoryRepository.GetAll();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<TeacherCategory>, IEnumerable<ViewTeacherCategory>>(teacherCategories);
            return viewModel;
        }

        public void DeleteTeacherCategory(int id)
        {
            var teacherCategory = this.unitOfWork.TeacherCategoryRepository.GetById(id);
            teacherCategory.Teachers.RemoveAll(category => teacherCategory.Id == id);
            this.unitOfWork.TeacherCategoryRepository.Delete(teacherCategory);
            this.SaveTeacherCategory();
        }

        public ViewTeacherCategory GetTeacherCategoryById(int id)
        {
            var teacherCategory = this.unitOfWork.TeacherCategoryRepository.GetById(id);
            var viewModel = AutoMapper.Mapper.Map<TeacherCategory, ViewTeacherCategory>(teacherCategory);
            return viewModel;
        }

        public void UpdateTeacherCategory(int id, ViewTeacherCategory value)
        {
            var teacherCategory = this.unitOfWork.TeacherCategoryRepository.GetById(id);
            AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(value, teacherCategory);
            this.unitOfWork.TeacherCategoryRepository.Update(teacherCategory);
            this.SaveTeacherCategory();
        }

        public void SaveTeacherCategory()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
