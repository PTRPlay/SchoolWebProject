using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        Group Get(Expression<Func<Group, bool>> expression);

        void RemoveGroup(int id);

        void SaveChanges();
    }
}
