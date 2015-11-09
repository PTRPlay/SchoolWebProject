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
        private ILogger tmpLogger;
        private DbFactory dbFactory;
        private GenericRepository<Teacher> repository;
        private GenericRepository<User> userRepository;
        private UnitOfWork unitOfWork;

        public TeacherService(ILogger logger) : base(logger)
        {
            this.tmpLogger = logger;
            this.dbFactory = new DbFactory();
            this.repository = new GenericRepository<Teacher>(this.dbFactory);
            this.unitOfWork = new UnitOfWork(this.dbFactory);
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
