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
        private IRepository<School> repository;

        private IUnitOfWork unitOfWork;

        public SchoolService(ILogger logger, IRepository<School> schoolRepository, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.repository = schoolRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<School> GetAllSchools()
        {
            return this.repository.GetAll();
        }

        public School GetSchoolById(int id)
        {
            return this.repository.GetById(id);
        }

        public void UpdateSchool(School school)
        {
            this.repository.Update(school);
        }

        public void AddSchool(School school)
        {
            this.repository.Add(school);
        }

        public void RemoveSchool(School school)
        {
            this.repository.Delete(school);
        }

        public void SaveSchool()
        {
            unitOfWork.SaveChanges();
        }
    }
}
