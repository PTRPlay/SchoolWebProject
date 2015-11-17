﻿using System;
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
            return unitOfWork.TeacherRepository.GetById(id);
        }

        public void UpdateProfile(Teacher teacher)
        {
            unitOfWork.TeacherRepository.Update(teacher);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.unitOfWork.TeacherRepository.Add(teacher);
            //repository.Add(teacher);
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
