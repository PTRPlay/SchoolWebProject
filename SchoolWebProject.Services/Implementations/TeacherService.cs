using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        private IUnitOfWork unitOfWork;
        private ISubjectService subjectService;

        public TeacherService(ILogger logger, IUnitOfWork teacherUnitOfWork,ISubjectService subjectService) : base(logger)
        {
            this.unitOfWork = teacherUnitOfWork;
            this.subjectService = subjectService;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            List<Teacher> listOfTeachers = new List<Teacher>();
            listOfTeachers = this.unitOfWork.TeacherRepository.GetAll().ToList();
            return listOfTeachers;
        }

        public Teacher GetProfileById(int id)
        {
            return this.unitOfWork.TeacherRepository.GetById(id);
        }

        public IEnumerable<Teacher> GetByName(string filter)
        {
            return this.unitOfWork.TeacherRepository.GetAll().
                Where((enty) => (enty.LastName).Contains(filter));
        }

        public Teacher Get(Expression<Func<Teacher, bool>> expression)
        {
            return unitOfWork.TeacherRepository.Get(expression);
        }

        public void UpdateProfile(Teacher teacher)
        {
            foreach (var subject in teacher.Subjects)
            {
                var temp = this.unitOfWork.SubjectRepository.GetById(subject.Id);
                this.unitOfWork.SubjectRepository.Attach(temp);
            }
            this.unitOfWork.TeacherRepository.Update(teacher);
            this.unitOfWork.SaveChanges();
        }
        
        public void AddTeacher(Teacher teacher)
        {
            this.unitOfWork.TeacherRepository.Add(teacher);
            this.SaveTeacher();
        }

        public int GetIdByName(string FirstName , string LastName , string MiddleName)
        {
            var teachers = this.unitOfWork.TeacherRepository.GetAll();
            return teachers.FirstOrDefault(t => t.FirstName == FirstName && t.MiddleName == MiddleName && t.LastName == LastName).Id;
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.unitOfWork.TeacherRepository.Delete(teacher);
            this.SaveTeacher();
        }

        public void SaveTeacher()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
