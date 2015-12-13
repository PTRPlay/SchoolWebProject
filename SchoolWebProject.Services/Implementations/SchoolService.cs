using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;

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

        public IEnumerable<ViewSchool> GetAllSchools()
        {
            var schools = this.unitOfWork.SchoolRepository.GetAll();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<School>, IEnumerable<ViewSchool>>(schools);
            return viewModel;
        }

        public ViewSchool GetSchoolById(int id)
        {
            var school = this.unitOfWork.SchoolRepository.GetById(id);
            var viewModel = AutoMapper.Mapper.Map<School, ViewSchool>(school);
            return viewModel;
        }

        public void SaveSchool()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
