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

        Pupil GetProfileById(int id);

        void UpdateProfile(Pupil pupil);

        void AddPupil(Pupil pupil);

        void RemovePupil(Pupil pupil);

        void SavePupil();
    }
}
