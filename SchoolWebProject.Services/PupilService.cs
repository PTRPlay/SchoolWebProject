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
        private IRepository<Pupil> repository;

        private IUnitOfWork unitOfWork;

        public PupilService(ILogger logger, IRepository<Pupil> pupilRepository, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.repository = pupilRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Pupil> GetAllPupils()
        {
            return this.repository.GetAll().OrderBy(p=>p.LastName);
        }

        public IEnumerable<Pupil> GetPage(int pageNumb, int amount, string sorting)
        {
            if(sorting.ToLower() == "desc")
            return this.repository.GetAll().OrderByDescending(p => p.LastName).Skip((pageNumb-1) * amount).Take(amount);
            else
                return this.repository.GetAll().OrderBy(p => p.LastName).Skip((pageNumb - 1) * amount).Take(amount);

        }

        public Pupil GetProfileById(int id)
        {
            return this.repository.GetById(id);
        }

        public void UpdateProfile(Pupil pupil)
        {
            this.repository.Update(pupil);
        }

        public void AddPupil(Pupil pupil)
        {
            this.repository.Add(pupil);
        }

        public void RemovePupil(Pupil pupil)
        {
            this.repository.Delete(pupil);
        }

        public void SavePupil()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
