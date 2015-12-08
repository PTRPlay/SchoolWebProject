using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface IPupilService
    {
        IEnumerable<Pupil> GetAllPupils();

        IEnumerable<Pupil> GetPage(int page, int amount, string sorting, string filtering, out int pageCount);

        Pupil GetProfileById(int id);

        void UpdateProfile(Pupil pupil);

        void AddPupil(Pupil pupil);

        void RemovePupil(int id);

        Pupil Get(Expression<Func<Pupil, bool>> expression);
    }
}
