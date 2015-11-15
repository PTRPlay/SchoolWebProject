using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;


namespace SchoolWebProject.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private GenericRepository<User> userRepository;
        private GenericRepository<LogInData> userLoginRepository;
        private GenericRepository<Role> rolesRepository;

        public AccountService(ILogger logger, GenericRepository<User> inputRepository, GenericRepository<LogInData> inloginrepo, GenericRepository<Role>inputRoles)
            : base(logger)
        {
            this.userRepository = inputRepository;
            this.userLoginRepository = inloginrepo;
            this.rolesRepository = inputRoles;
        }

        public User GetUser(string userName, string password)
        {
            Expression<Func<User, bool>> getUserByLogin = user => user.LogInData.Login == userName;
            User currentUser;
            currentUser = this.userRepository.Get(getUserByLogin);
            if (currentUser == null) return currentUser;
            Expression<Func<LogInData, bool>> getLoginData = login => login.UserId == currentUser.Id;
            LogInData logindata = this.userLoginRepository.Get(getLoginData);
            if (this.CheckUser(logindata, password) && currentUser != null)
                return currentUser;
            else return null;
        }

        public LogInData GetUserLogInData(int id)
        {
            Expression<Func<LogInData, bool>> getLoginData = login => login.UserId == id;
            return userLoginRepository.Get(getLoginData);
        }

        public Role GetRoleById(int? id)
        {
            Expression<Func<Role, bool>> getRole = role => role.Id == id;
            return rolesRepository.Get(getRole);
        }

        public Dictionary<string,string> GetUserRaws(string role)
        {
            var permisions = new Dictionary<string, string>();
            switch (role)
            {
                case "admin":
                    permisions["Teachers"] = "teachers";
                    permisions["Subjects"] = "subjects";
                    permisions["Pupils"] = "pupils";
                    permisions["Groups"] = "groups";
                    permisions["Scheldule"] = "scheldule";
                    permisions["Journal"] = "journal";
                    permisions["News"] = "newsService";
                    permisions["Contacts"] = "schoolService";
                    break;
                default:

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

        public string CreateSalt()
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