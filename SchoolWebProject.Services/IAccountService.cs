using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services
{
    public interface IAccountService
    {
        User GetUser(string userName, string password);
        string CreateHashPassword(string inputPassword, string salt);
        string CreateSalt();
    }
}
