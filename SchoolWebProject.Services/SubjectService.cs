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
    public class SubjectService : BaseService, ISubjectService
    {
        private ILogger subjectLogger;

        private IRepository<Subject> repository;

        private IUnitOfWork unitOfWork;

        public SubjectService(ILogger logger)
            : base(logger)
        {
            this.subjectLogger = logger;
            this.repository = new GenericRepository<Subject>(new DbFactory());
            this.unitOfWork = new UnitOfWork(new DbFactory());
        }

        public IEnumerable<Subject> GetAllSubject()
        {
            return this.repository.GetAll();
        }

        public Subject GetSubjectById(int id)
        {
            return this.repository.GetById(id);
        }

        public void UpdateSubject(Subject subject)
        {
            this.repository.Update(subject);
        }

        public void AddSubject(Subject subject)
        {
            repository.Add(subject);
        }

        public void RemoveSubject(Subject subject)
        {
            repository.Delete(subject);
        }

        public void SaveSubject()
        {
            unitOfWork.SaveChanges();
        }
    }
}