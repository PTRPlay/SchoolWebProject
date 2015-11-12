using System;
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
        private GenericRepository<LogInData> loginRepo;

        public AccountService(ILogger logger, GenericRepository<User> inputRepository, GenericRepository<LogInData> inloginrepo)
            : base(logger)
        {
            this.userRepository = inputRepository;
            this.loginRepo = inloginrepo;
        }

        public User GetUser(string userName, string password)
        {
            Expression<Func<User, bool>> getUserByLogin = user => user.LogInData.Login == userName;
            User currentUser = this.userRepository.Get(getUserByLogin);
            Expression<Func<LogInData, bool>> getLoginData = login => login.UserId == currentUser.Id;
            LogInData logindata = this.loginRepo.Get(getLoginData);
            if (this.CheckUser(logindata, password) && currentUser != null)
                return currentUser;
            else return null;
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