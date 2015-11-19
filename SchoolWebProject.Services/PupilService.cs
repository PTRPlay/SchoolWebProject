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
            return unitOfWork.PupilRepository.GetAll().OrderBy(p=>p.LastName);
        }

        public IEnumerable<Pupil> GetPage(int pageNumb, int amount, string sorting, string filtering, out int pageCount)
        {
            IEnumerable<Pupil> pupils = null;
            if (filtering != null)
            {
                pupils = unitOfWork.PupilRepository.GetAll().Where(p => p.LastName.StartsWith(filtering));
                pageCount = pupils.Count();

                switch(sorting)
                {
                    case "desc":
                        return pupils.OrderByDescending(p => p.LastName).Skip((pageNumb - 1) * amount).Take(amount); 
                    default:
                         return pupils.OrderBy(p => p.LastName).Skip((pageNumb - 1) * amount).Take(amount);
                }
            }
            
            if (sorting.ToLower() == "desc")
            {
                pupils = unitOfWork.PupilRepository.GetAll().OrderByDescending(p => p.LastName);
            }
            else
            {
                 pupils = unitOfWork.PupilRepository.GetAll().OrderBy(p => p.LastName);
            }

            pageCount = pupils.Count();
            return pupils.Skip((pageNumb - 1) * amount).Take(amount); 
        }

        public Pupil GetProfileById(int id)
        {
            return this.unitOfWork.PupilRepository.GetById(id);
        }

        public void UpdateProfile(Pupil pupil)
        {
            unitOfWork.PupilRepository.Update(pupil);
            unitOfWork.SaveChanges();

        }

        public void AddPupil(Pupil pupil)
        {
            unitOfWork.PupilRepository.Add(pupil);
            unitOfWork.SaveChanges();

        }

        public void RemovePupil(int id)
        {
            Pupil pupil = this.unitOfWork.PupilRepository.GetById(id); 
            unitOfWork.PupilRepository.Delete(pupil);
            unitOfWork.SaveChanges();

        }

    }
}
