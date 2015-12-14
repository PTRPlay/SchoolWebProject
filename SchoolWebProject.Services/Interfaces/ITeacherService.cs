using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public interface ITeacherService
    {
        IEnumerable<SchoolWebProject.Domain.Models.Teacher> GetAllTeachers();

        SchoolWebProject.Domain.Models.Teacher GetProfileById(int id);

        void UpdateProfile(SchoolWebProject.Domain.Models.Teacher teacher);

        void AddTeacher(SchoolWebProject.Domain.Models.Teacher teacher);

        void RemoveTeacher(SchoolWebProject.Domain.Models.Teacher teacher);

        int GetIdByName(string FirstName, string LastName, string MiddleName);

        IEnumerable<SchoolWebProject.Domain.Models.Teacher> GetByName(string filter);

        void SaveTeacher();
    }
}
