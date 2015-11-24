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

        private IUnitOfWork unitOfWork;

        public SubjectService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.subjectLogger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Subject> GetAllSubject()
        {
            return this.unitOfWork.SubjectRepository.GetAll();
        }

        public Subject GetSubjectById(int id)
        {
            return this.unitOfWork.SubjectRepository.GetById(id);
        }

        public void UpdateSubject(Subject subject)
        {
            this.unitOfWork.SubjectRepository.Update(subject);
        }

        public void AddSubject(Subject subject)
        {
            unitOfWork.SubjectRepository.Add(subject);
        }

        public void RemoveSubject(Subject subject)
        {
            unitOfWork.SubjectRepository.Delete(subject);
        }

        public void SaveSubject()
        {
            unitOfWork.SaveChanges();
        }
    }
}