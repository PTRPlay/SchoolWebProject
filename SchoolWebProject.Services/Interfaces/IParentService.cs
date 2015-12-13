using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;
using System.Linq.Expressions;

namespace SchoolWebProject.Services.Interfaces
{
    public interface IParentService
    {
        IEnumerable<Parent> GetAllParents();

        IEnumerable<Parent> GetPage(int pageNumb, int amount, string sorting, string filtering, out int pageCount);

        Parent GetParent(int id);

        Parent Get(Expression<Func<Parent, bool>> expression);

        void AddParent(Parent parent);

        void RemoveParent(int id);

        void UpdateParent(Parent parent);
    }
}
