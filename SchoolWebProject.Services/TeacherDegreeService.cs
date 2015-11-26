using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public class TeacherDegreeService : BaseService, ITeacherDegreeService
    {
        private IUnitOfWork unitOfWork;

        public TeacherDegreeService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddTeacherDegree (TeacherDegree teacherDegree)
        {
            this.unitOfWork.TeacherDegreeRepository.Add(teacherDegree);
        }

        public IEnumerable<TeacherDegree> GetAllTeacherCategories()
        {
            return this.unitOfWork.TeacherDegreeRepository.GetAll();
        }

        public void DeleteTeacherDegree(int id)
        {
            TeacherDegree teacherDegree = this.unitOfWork.TeacherDegreeRepository.GetById(id);
            teacherDegree.Teachers.RemoveAll(degree => teacherDegree.Id == id);
            this.unitOfWork.TeacherDegreeRepository.Delete(teacherDegree);
        }

        public TeacherDegree GetTeacherDegreeById(int id)
        {
            return this.unitOfWork.TeacherDegreeRepository.GetById(id);
        }

        public void UpdateTeacherDegree(TeacherDegree teacherDegree)
        {
            this.unitOfWork.TeacherDegreeRepository.Update(teacherDegree);
        }

        public void SaveTeacherDegree()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
