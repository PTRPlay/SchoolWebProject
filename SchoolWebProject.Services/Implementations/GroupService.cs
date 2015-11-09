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

        public GroupService(ILogger logger, IRepository<Group> groupRepository, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.repository = groupRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return repository.GetAll().ToList();
        }

        public Group GetGroupById(int id)
        {
            return repository.GetById(id);
        }

        public void UpdateGroup(Group group)
        {
            repository.Update(group);
        }

        public void AddGroup(Group group)
        {
            repository.Add(group);
        }

        public void RemoveGroup(Group group)
        {
            repository.Delete(group);
        }

        public void SaveChanges()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
