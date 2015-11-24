using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services.Implementations
{
    public class GroupService:BaseService, IGroupService
    {
        private IRepository<Group> repository;
        private IUnitOfWork unitOfWork;

        public GroupService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return unitOfWork.GroupRepository.GetAll().ToList(); 
        }

        public Group GetGroupById(int id)
        {
            return unitOfWork.GroupRepository.GetById(id);
        }

        public void UpdateGroup(Group group)
        {
            unitOfWork.GroupRepository.Update(group);
        }

        public void AddGroup(Group group)
        {
            unitOfWork.GroupRepository.Add(group);
        }

        public void RemoveGroup(Group group)
        {
            unitOfWork.GroupRepository.Delete(group);
        }

        public void SaveChanges()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
