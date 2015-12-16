using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
    }
}
