using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services.Interfaces;
using System.Linq.Expressions;

namespace SchoolWebProject.Services
{
    public class ParentService : BaseService, IParentService 
    {
        private IUnitOfWork unitOfWork;

        public ParentService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Parent> GetAllParents()
        {
            return this.unitOfWork.ParentRepository.GetAll().OrderBy(a => a.LastName);
        }

        public Parent GetParent(int id)
        {
            return this.unitOfWork.ParentRepository.GetById(id);
        }

        public Parent Get(Expression<Func<Parent, bool>> expression)
        {
            return this.unitOfWork.ParentRepository.Get(expression);
        }

        public void AddParent(Parent parent)
        {
            this.unitOfWork.ParentRepository.Add(parent);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateParent(Parent parent)
        {
            this.unitOfWork.ParentRepository.Update(parent);
            this.unitOfWork.SaveChanges();
        }

        public void RemoveParent(int id)
        {
            this.unitOfWork.ParentRepository.Delete(this.unitOfWork.ParentRepository.GetById(id));
            this.unitOfWork.SaveChanges();
        }
    }
}
