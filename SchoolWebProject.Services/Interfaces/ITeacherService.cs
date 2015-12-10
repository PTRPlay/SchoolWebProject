﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAllTeachers();

        Teacher GetProfileById(int id);

        void UpdateProfile(Teacher teacher);

        void AddTeacher(Teacher teacher);

        void RemoveTeacher(Teacher teacher);

        int GetIdByName(string FirstName, string LastName, string MiddleName);

        void SaveTeacher();
    }
}