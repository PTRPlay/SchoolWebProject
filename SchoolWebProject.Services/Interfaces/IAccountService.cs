using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Services
{
    public interface IAccountService
    {
        User GetUser(string userName, string password);

        string CreateHashPassword(string inputPassword, string salt);

        LogInData GetUserLogInData(int id);

        Role GetRoleById(int? id);

        Dictionary<string, string> GetUserRaws(Constants.UserRoles role);

        LogInData GenerateUserLoginData(User user, IEmailSenderService emailSender);

        string GenerateLogin(User user);
    }
}
