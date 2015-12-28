using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public interface ITeacherCategoryService
    {
        IEnumerable<ViewTeacherCategory> GetAllTeacherCategories();

        ViewTeacherCategory GetTeacherCategoryById(int id);

        void UpdateTeacherCategory(int id, ViewTeacherCategory teacherCategory);

        void AddTeacherCategory(ViewTeacherCategory teacherCategory);

    }
}
