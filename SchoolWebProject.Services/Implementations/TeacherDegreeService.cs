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
    public class TeacherDegreeService : BaseService, ITeacherDegreeService
    {
        private IUnitOfWork unitOfWork;

        public TeacherDegreeService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddTeacherDegree(ViewTeacherDegree value)
        {
            var teacherDegree = AutoMapper.Mapper.Map<ViewTeacherDegree, TeacherDegree>(value);
            this.unitOfWork.TeacherDegreeRepository.Add(teacherDegree);
            this.SaveTeacherDegree();
        }

        public IEnumerable<ViewTeacherDegree> GetAllTeacherDegrees()
        {
            var teacherDegrees = this.unitOfWork.TeacherDegreeRepository.GetAll();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<TeacherDegree>, IEnumerable<ViewTeacherDegree>>(teacherDegrees);
            return viewModel;
        }

        public void DeleteTeacherDegree(int id)
        {
            TeacherDegree teacherDegree = this.unitOfWork.TeacherDegreeRepository.GetById(id);
            if (teacherDegree == null)
            {
                logger.Error("Trying to delete teacher degree with null");
                throw new NullReferenceException();
            }

            this.unitOfWork.TeacherDegreeRepository.Delete(teacherDegree);
            this.SaveTeacherDegree();
        }

        public ViewTeacherDegree GetTeacherDegreeById(int id)
        {
            if (id < 0)
            {
                this.logger.Error("Trying to get teacher degree with id < 0");
                throw new ArgumentException();
            }
            var teacherDegree = this.unitOfWork.TeacherDegreeRepository.GetById(id);
            AutoMapper.Mapper.CreateMap<TeacherDegree, ViewTeacherDegree>();
            var viewModel = AutoMapper.Mapper.Map<TeacherDegree, ViewTeacherDegree>(teacherDegree);
            return viewModel;
        }

        public void UpdateTeacherDegree(int id, ViewTeacherDegree value)
        {
            var teacherDegree = this.unitOfWork.TeacherDegreeRepository.GetById(id);
            AutoMapper.Mapper.Map<ViewTeacherDegree, TeacherDegree>(value, teacherDegree);
            this.unitOfWork.TeacherDegreeRepository.Update(teacherDegree);
            this.SaveTeacherDegree();
        }

        private void SaveTeacherDegree()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
