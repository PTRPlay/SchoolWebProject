using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public interface ITeacherDegreeService
    {
        IEnumerable<ViewTeacherDegree> GetAllTeacherDegrees();

        ViewTeacherDegree GetTeacherDegreeById(int id);

        void UpdateTeacherDegree(ViewTeacherDegree teacherDegree);

        void AddTeacherDegree(ViewTeacherDegree teacherDegree);

        void SaveTeacherDegree();
    }
}
