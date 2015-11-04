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
        private GenericRepository<Teacher> repository;

        public TeacherService(ILogger logger, GenericRepository<Teacher> teacherRepository) : base(logger)
        {
            repository = teacherRepository;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
           return repository.GetAll().ToList();
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
