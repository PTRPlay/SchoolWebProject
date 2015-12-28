using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using UnidecodeSharpFork;

namespace SchoolWebProject.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private IUnitOfWork unitOfWork;

        public AccountService(ILogger logger, IUnitOfWork unit)
            : base(logger)
        {
            this.unitOfWork = unit;
        }

        public LogInData GenerateUserLoginData(User user, IEmailSenderService emailSender)
        {
            string userLogin = this.GenerateLogin(user), userPassword = this.GeneratePassword(), salt = this.CreateSalt();
            string message = string.Format(Constants.EmailMessage + "\nЛогін: " + userLogin + "\nПароль: " + userPassword);
            emailSender.SendMail(user.Email, message);
            return new LogInData
                {
                    Login = userLogin,
                    PasswordSalt = salt,
                    PasswordHash = this.CreateHashPassword(userPassword, salt)
                };
        }

        public User GetUser(string userName, string password)
        {
            Expression<Func<LogInData, bool>> getUserByLogin = user => user.Login == userName;
            LogInData loginData;
            loginData = this.unitOfWork.LogInDataRepository.Get(getUserByLogin);
            if (loginData == null)
            {
                return null;
            }

            if (this.CheckUser(loginData, password) && loginData != null)
            {
                return this.unitOfWork.UserRepository.GetById(loginData.UserId);
            }
            else
            {
                return null;
            }
        }

        public LogInData GetUserLogInData(int id)
        {
            Expression<Func<LogInData, bool>> getLoginData = login => login.UserId == id;
            return this.unitOfWork.LogInDataRepository.Get(getLoginData);
        }

        public Role GetRoleById(int? id)
        {
            if (id == null)
            {
                logger.Warning("Tryed to get Role by null value id");
                return null;
            }
            else
                return this.unitOfWork.RoleRepository.Get(role => role.Id == id);
        }

        public Dictionary<string, string> GetUserRaws(Constants.UserRoles role)
        {
            switch (role)
            {
                case Constants.UserRoles.Admin:
                    return Constants.AdminPermissions;
                    break;
                case Constants.UserRoles.Teacher:
                    return Constants.TeacherPermissions;
                    break;
                case Constants.UserRoles.Pupil:
                    return Constants.PupilPermissions;
                    break;
                case Constants.UserRoles.Parent:
                    return Constants.ParentPermissions;
                    break;
                default:
                    return null;
                    break;
            }
        }

        public string CreateHashPassword(string inputPassword, string salt)
        {
            string fullPassword = string.Format(inputPassword + salt);
            byte[] hash = SHA256.Create().ComputeHash(Constants.StringToByteArray(fullPassword));
            return Constants.ByteArrayToString(hash);
        }

        public User GetCurrentUserProfile(string userLogin)
        {
            return this.unitOfWork.UserRepository.Get(user => user.LogInData.Login == userLogin);
        }

        public string CreateSalt()
        {
            RNGCryptoServiceProvider cryptographer = new RNGCryptoServiceProvider();
            int saltLength = 24;
            byte[] salt = new byte[saltLength];
            cryptographer.GetBytes(salt);
            return Constants.ByteArrayToString(salt);
        }

        private string GenerateLogin(User user)
        {
            string convertionString = string.Format(user.LastName + user.FirstName.Substring(0, 1) + user.RoleId);
            return Unidecoder.Unidecode(convertionString).ToLower();
        }

        private string GeneratePassword(int passwordLength = 8)
        {
            int numberOfSpecialSymbols = 2;
            return Membership.GeneratePassword(passwordLength, numberOfSpecialSymbols);
        }

        private bool CheckUser(LogInData currUser, string password)
        {
            if (currUser.PasswordHash == this.CreateHashPassword(password, currUser.PasswordSalt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}