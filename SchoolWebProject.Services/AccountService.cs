using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Cryptography;
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
        private IEmailSenderService emailService;

        public AccountService(ILogger logger, IUnitOfWork unit)
            : base(logger)
        {
            this.unitOfWork = unit;
            this.emailService = new EmailSenderService(logger, this);
        }

        public LogInData GenerateUserLoginData(User user)
        {
            string userLogin = GenerateLogin(user), userPassword = GeneratePassword(), salt = CreateSalt();
            string message = string.Format(Constants.EmailMessage + "\nЛогін: " + userLogin + "\nПароль: " + userPassword);
            emailService.SendMail(user.Email, message);
            return new LogInData
                {
                    Login = userLogin,
                    PasswordSalt = salt,
                    PasswordHash = CreateHashPassword(userPassword,salt)
                };
        }

        public User GetUser(string userName, string password)
        {
            Expression<Func<LogInData, bool>> getUserByLogin = user => user.Login == userName;
            LogInData loginData;
            loginData = this.unitOfWork.LogInDataRepository.Get(getUserByLogin);
            if (loginData == null) return null;
            if (this.CheckUser(loginData, password) && loginData != null)
            {
                Expression<Func<User, bool>> getUser = user => user.Id == loginData.UserId;
                return this.unitOfWork.UserRepository.Get(getUser);
            }
            else return null;
        }

        public LogInData GetUserLogInData(int id)
        {
            Expression<Func<LogInData, bool>> getLoginData = login => login.UserId == id;
            return this.unitOfWork.LogInDataRepository.Get(getLoginData);
        }

        public Role GetRoleById(int? id)
        {
            Expression<Func<Role, bool>> getRole = role => role.Id == id;
            return this.unitOfWork.RoleRepository.Get(getRole);
        }

        public Dictionary<string, string> GetUserRaws(Constants.UserRoles role)
        {
            var permisions = new Dictionary<string, string>();
            switch (role)
            {
                case Constants.UserRoles.Admin:
                    permisions["Вчителі"] = "teachers";
                    permisions["Предмети"] = "subjects";
                    permisions["Учні"] = "pupils";
                    permisions["Класи"] = "groups";
                    permisions["Розклад"] = "schedule";
                    permisions["Новини"] = "newsService";
                    permisions["Контакти"] = "schoolService";
                    break;
                case Constants.UserRoles.Teacher:
                    permisions["Учні"] = "pupils";
                    permisions["Класи"] = "groups";
                    permisions["Розклад"] = "scheldule";
                    permisions["Журнал"] = "journal";
                    permisions["Новини"] = "newsService";
                    permisions["Контакти"] = "schoolService";
                    break;
                case Constants.UserRoles.Pupil:
                    permisions["Щоденник"] = "diaryService";
                    permisions["Розклад"] = "scheldule";
                    permisions["Журнал"] = "journal";
                    permisions["Новини"] = "newsService";
                    permisions["Контакти"] = "schoolService";
                    break;
                case Constants.UserRoles.Parent:
                    permisions["Вчителі"] = "teachers";
                    permisions["Розклад"] = "scheldule";
                    permisions["Журнал"] = "journal";
                    permisions["Новини"] = "newsService";
                    permisions["Конткти"] = "schoolService";
                    break;
                default:
                    permisions = null;
                    break;
            }
            return permisions;
        }

        public string CreateHashPassword(string inputPassword, string salt)
        {
            string fullPassword = string.Format(inputPassword + salt);
            byte[] hash = SHA256.Create().ComputeHash(this.StringToByteArray(fullPassword));
            return this.ByteArrayToString(hash);
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

        private string CreateSalt()
        {
            RNGCryptoServiceProvider cryptographer = new RNGCryptoServiceProvider();
            int saltLength = 24;
            byte[] salt = new byte[saltLength];
            cryptographer.GetBytes(salt);
            return this.ByteArrayToString(salt);
        }

        private bool CheckUser(LogInData currUser, string password)
        {
            if (currUser.PasswordHash == CreateHashPassword(password, currUser.PasswordSalt))
                return true;
            else return false;
        }

        private string ByteArrayToString(byte[] input)
        {
            char[] output = new char[input.Length / sizeof(char)];
            System.Buffer.BlockCopy(input, 0, output, 0, input.Length);
            return new string(output);
        }

        private byte[] StringToByteArray(string input)
        {
            byte[] output = new byte[input.Length * sizeof(char)];
            System.Buffer.BlockCopy(input.ToCharArray(), 0, output, 0, output.Length);
            return output;
        }
    }
}