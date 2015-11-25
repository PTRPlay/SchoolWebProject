﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        private IUnitOfWork unitOfWork;

        public TeacherService(ILogger logger, IUnitOfWork teacherUnitOfWork): base(logger)
        {
            this.teacherLogger = logger;
            this.unitOfWork = teacherUnitOfWork;
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

        public Teacher Get(Expression<Func<Teacher,bool>> expression)
        {
            return unitOfWork.TeacherRepository.Get(expression);
        }

        public void UpdateProfile(Teacher teacher)
        {
            Subject temp = new Subject();
            foreach (var subject in teacher.Subjects)
            {
                //subject.Teachers);    

                this.unitOfWork.SubjectRepository.GetById(subject.Id).Teachers.Add(teacher);
                //temp.Teachers.Add(teacher);
                //this.unitOfWork.SubjectRepository.Attach(temp);

            }
            //this.unitOfWork.SubjectRepository.Attach(teacher.Subjects[0]);
            //teacher.Subjects[0] = this.unitOfWork.SubjectRepository.GetById(teacher.Subjects[0].Id);
            //this.unitOfWork.SubjectRepository.Add(teacher.Subjects[0]);
            this.unitOfWork.SubjectRepository.Attach(temp);
            this.unitOfWork.TeacherRepository.Update(teacher);
            this.unitOfWork.SaveChanges();
        }

        public void AddTeacher(Teacher teacher)
        {
            foreach (var subject in teacher.Subjects) 
            { 
                this.unitOfWork.SubjectRepository.Update(subject); 
            }

            this.unitOfWork.TeacherRepository.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.unitOfWork.TeacherRepository.Delete(teacher);
        }

        public void SaveTeacher()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
