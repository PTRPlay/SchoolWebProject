using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public class PupilService : BaseService, IPupilService
    {
        private IUnitOfWork unitOfWork;

        public PupilService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
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
                pupils = unitOfWork.PupilRepository.GetAll().Where(p => p.LastName.ToLower().StartsWith(filtering.ToLower()));
                pageCount = pupils.Count();
                pupils = pupils.AsQueryable().OrderBy(sorting).Skip((pageNumb - 1) * amount).Take(amount); 
                return pupils;
            }

            pupils = unitOfWork.PupilRepository.GetAll().AsQueryable().OrderBy(sorting);
            pageCount = pupils.Count();
            pupils = pupils.Skip((pageNumb - 1) * amount).Take(amount);
            return pupils;
        }

        public Pupil GetProfileById(int id)
        {
            return this.unitOfWork.PupilRepository.GetById(id);
        }

        public Pupil Get(Expression<Func<Pupil, bool>> expression)
        {
            return unitOfWork.PupilRepository.Get(expression);
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
