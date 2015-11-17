using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public class PupilService : BaseService, IPupilService
    {
        private ILogger pupilLogger;

        private IUnitOfWork unitOfWork;

        public PupilService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.pupilLogger =logger;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Pupil> GetAllPupils()
        {
            return this.unitOfWork.PupilRepository.GetAll().OrderBy(p=>p.LastName);
        }

        public IEnumerable<Pupil> GetPage(int pageNumb, int amount, string sorting)
        {
            if(sorting.ToLower() == "desc")
                return this.unitOfWork.PupilRepository.GetAll().OrderByDescending(p => p.LastName).Skip((pageNumb - 1) * amount).Take(amount);
            else
                return this.unitOfWork.PupilRepository.GetAll().OrderBy(p => p.LastName).Skip((pageNumb - 1) * amount).Take(amount);

        }

        public Pupil GetProfileById(int id)
        {
            return this.unitOfWork.PupilRepository.GetById(id);
        }

        public void UpdateProfile(Pupil pupil)
        {
            this.unitOfWork.PupilRepository.Update(pupil);
        }

        public void AddPupil(Pupil pupil)
        {
            unitOfWork.SaveChanges();
            this.unitOfWork.PupilRepository.Add(pupil);
        }

        public void RemovePupil(Pupil pupil)
        {
            this.unitOfWork.PupilRepository.Delete(pupil);
        }

        public void SavePupil()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
