using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;
using sModels = SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public interface IPupilService
    {
        IEnumerable<Pupil> GetAllPupils();

        IEnumerable<Pupil> GetPage(int page, int amount, string sorting, string filtering, out int pageCount);

        Pupil GetProfileById(int id);

        void UpdateProfile(sModels.ViewPupil pupil);

        void AddPupil(sModels.ViewPupil pupil);

        void RemovePupil(int id);

        Pupil Get(Expression<Func<Pupil, bool>> expression);
    }
}
