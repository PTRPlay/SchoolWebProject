using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject;

namespace SchoolWebProject.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        private ILogger teacherLogger;
        private IRepository<Teacher> repository;
        private IUnitOfWork unitOfWork;

        public TeacherService(ILogger logger, IRepository<Teacher> teacherRepository, IUnitOfWork teacherUnitOfWork): base(logger)
        {
            this.teacherLogger = logger;
            this.repository = teacherRepository;
            this.unitOfWork = teacherUnitOfWork;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            List<Teacher> listOfTeachers = new List<Teacher>();
            listOfTeachers = repository.GetAll().ToList();
            return listOfTeachers;
        }

        public Teacher GetProfileById(int id)
        {
           return repository.GetById(id);
        }

        public void UpdateProfile(Teacher teacher)
        {
            repository.Update(teacher);
        }

        public void AddTeacher(Teacher teacher)
        {
            repository.Add(teacher);
            unitOfWork.SaveChanges();
        }

        public void RemoveTeacher(Teacher teacher)
        {
            repository.Delete(teacher);
        }
    }
}
