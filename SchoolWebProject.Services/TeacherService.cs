﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        public TeacherService(ILogger logger) : base(logger)
        {
        }

        public List<Teacher> GetTeachers()
        {
            throw new NotImplementedException();
        }

        public Teacher GetProfile()
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void AddTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void RemoveTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
