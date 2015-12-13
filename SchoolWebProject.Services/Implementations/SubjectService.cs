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
        private IUnitOfWork unitOfWork;

        public SubjectService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return this.unitOfWork.SubjectRepository.GetAll().ToList();
        }

        public Subject GetSubjectById(int id)
        {
            return this.unitOfWork.SubjectRepository.GetById(id);
        }

        public void UpdateSubject(Subject subject)
        {
            this.unitOfWork.SubjectRepository.Update(subject);
            unitOfWork.SaveChanges();
        }

        public void AddSubject(Subject subject)
        {
            var copy = this.unitOfWork.SubjectRepository.Get(s => s.Name == subject.Name);

            if (copy==null)
            {
                unitOfWork.SubjectRepository.Add(subject);
                unitOfWork.SaveChanges();
            }
        }

        public void RemoveSubject(int id)
        {
            Subject subject = unitOfWork.SubjectRepository.GetById(id);
            unitOfWork.SubjectRepository.Delete(subject);
            unitOfWork.SaveChanges();
        }

        public void SaveSubject()
        {
            unitOfWork.SaveChanges();
        }
    }
}