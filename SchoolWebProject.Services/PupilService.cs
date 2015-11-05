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
    class PupilService : BaseService, IPupilService
    {
        private IRepository<Pupil> repository;

        private IUnitOfWork unitOfWork;

        public PupilService(ILogger logger, IRepository<Pupil> pupilRepository, IUnitOfWork unitOfWork)
            : base(logger)
        {
            repository = pupilRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Pupil> GetAllPupils()
        {
            return repository.GetAll().Where(c => c.RoleId == 3);
        }

        public Pupil GetProfileById(int id)
        {
            return repository.GetById(id);
        }

        public void UpdateProfile(Pupil pupil)
        {
            repository.Update(pupil);
        }

        public void AddPupil(Pupil pupil)
        {
            repository.Add(pupil);
        }

        public void RemovePupil(Pupil pupil)
        {
            repository.Delete(pupil);
        }

        public void SavePupil()
        {
            unitOfWork.SaveChanges();
        }
    }
}
