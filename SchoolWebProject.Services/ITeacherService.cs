using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services
{
    interface ITeacherService
    {
        List<Teacher> GetTeachers();
        Teacher GetProfile();
        void UpdateProfile(Teacher teacher);
        void AddTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);
        
    }
}
