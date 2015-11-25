using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAllGroups();

        Group GetGroupById(int id);

        void UpdateGroup(Group group);

        void AddGroup(Group group);

        void RemoveGroup(int id);

        void SaveChanges();
    }
}
