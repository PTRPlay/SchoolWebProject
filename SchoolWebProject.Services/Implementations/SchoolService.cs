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
    public class SchoolService : BaseService, ISchoolService
    {
        private IUnitOfWork unitOfWork;

        public SchoolService(ILogger logger,  IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<School> GetAllSchools()
        {
            return this.unitOfWork.SchoolRepository.GetAll();
        }

        public School GetSchoolById(int id)
        {
            return this.unitOfWork.SchoolRepository.GetById(id);
        }

        public void UpdateSchool(School school)
        {
            this.unitOfWork.SchoolRepository.Update(school);
        }

        public void AddSchool(School school)
        {
            this.unitOfWork.SchoolRepository.Add(school);
        }

        public void RemoveSchool(School school)
        {
            this.unitOfWork.SchoolRepository.Delete(school);
        }

        public void SaveSchool()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
