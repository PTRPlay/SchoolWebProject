using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services
{
    public interface ITeacherCategoryService
    {
        IEnumerable<TeacherCategory> GetAllTeacherCategories();

        TeacherCategory GetTeacherCategoryById(int id);

        void UpdateTeacherCategory(TeacherCategory teacherCategory);

        void AddTeacherCategory(TeacherCategory teacherCategory);

        void SaveTeacherCategory();

    }
}
