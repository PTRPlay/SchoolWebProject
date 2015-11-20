using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services
{
    public interface ITeacherDegreeService
    {
        IEnumerable<TeacherDegree> GetAllTeacherCategories();

        TeacherDegree GetTeacherDegreeById(int id);

        void UpdateTeacherDegree(TeacherDegree teacherDegree);

        void AddTeacherDegree(TeacherDegree teacherDegree);

        void SaveTeacherDegree();

    }
}
