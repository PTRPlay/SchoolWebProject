using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface IPupilService
    {
        IEnumerable<Pupil> GetAllPupils();

        IEnumerable<Pupil> GetPage(int page, int amount, string sorting);

        Pupil GetProfileById(int id);

        void UpdateProfile(Pupil pupil);

        void AddPupil(Pupil pupil);

        void RemovePupil(int id);

        void SavePupil();
    }
}
