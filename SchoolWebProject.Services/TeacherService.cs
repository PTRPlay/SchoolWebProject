using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Data.Infrastructure;


namespace SchoolWebProject.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        private IRepository<Teacher> repository;
        private ILogger tmpLogger;

        public TeacherService(ILogger logger, IRepository<Teacher> teacherRepository)
            : base(logger)
        {
            this.tmpLogger = logger;
            this.repository = teacherRepository;
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
        }

        public void RemoveTeacher(Teacher teacher)
        {
            repository.Delete(teacher);
        }
    }
}
