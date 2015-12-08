using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface ISchoolService
    {
        IEnumerable<School> GetAllSchools();

        School GetSchoolById(int id);

        void UpdateSchool(School school);

        void AddSchool(School school);

        void RemoveSchool(School school);

        void SaveSchool();
    }
}
