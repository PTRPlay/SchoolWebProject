using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Models;

namespace SchoolWebProject.Services
{
    public interface ISchoolService
    {
        IEnumerable<ViewSchool> GetAllSchools();

        ViewSchool GetSchoolById(int id);

        void SaveSchool();
    }
}
