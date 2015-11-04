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
        private GenericRepository<User> logInRepository;

        public AccountService(ILogger logger, GenericRepository<User> inputRepository)
            : base(logger)
        {
            this.logInRepository = inputRepository;
        }

        public User GetUser(string userName, string password)
        {
            Expression<Func<User, bool>> getUserByLogin = user => user.LogInData.Login == userName;
            User currentUser = this.logInRepository.Get(getUserByLogin);
            if (this.CheckUser(currentUser, password))
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

        private bool CheckUser(User currUser, string password)
        {
            if (currUser.LogInData.PasswordHash == CreateHashPassword(password, currUser.LogInData.PasswordSalt))
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