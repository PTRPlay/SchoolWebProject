﻿using SchoolWebProject.Data.Infrastructure;
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
        
        private IUnitOfWork unitOfWork;

        public TeacherCategoryService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.teacherCategoryLogger = logger;
            this.unitOfWork = unitOfWork;
        }

        public void AddTeacherCategory (TeacherCategory teacherCategory)
        {
            this.unitOfWork.TeacherCategoryRepository.Add(teacherCategory);
        }

        public IEnumerable<TeacherCategory> GetAllTeacherCategories()
        {
            return this.unitOfWork.TeacherCategoryRepository.GetAll();
        }

        public void DeleteTeacherCategory(int id)
        {
            TeacherCategory teacherCategory = this.unitOfWork.TeacherCategoryRepository.GetById(id);
            teacherCategory.Teachers = null;
            this.unitOfWork.TeacherCategoryRepository.Delete(teacherCategory);
        }

        public TeacherCategory GetTeacherCategoryById(int id)
        {
            return this.unitOfWork.TeacherCategoryRepository.GetById(id);
        }

        public void UpdateTeacherCategory(TeacherCategory teacherCategory)
        {
            this.unitOfWork.TeacherCategoryRepository.Update(teacherCategory);
        }

        public void SaveTeacherCategory()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
