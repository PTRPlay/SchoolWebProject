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

        public User LogInService(string userName, string password)
        {
            try
            {
                Expression<Func<User, bool>> expression = user =>
                    user.LogInData.Login == userName && user.LogInData.PasswordHash == this.GetHashedPassword(password, user);
                User currentUser = this.logInRepository.Get(expression);
                return currentUser;
            }
            catch
            {
                // if user does not exist
                throw new Exception("Wrong login data!");
            }
        }

        private string GetHashedPassword(string password, User currUser)
        {
            // connect input password with user`s salt
            string passwordPlusSalt = string.Format(password + currUser.LogInData.PasswordSalt);

            // transform input string to byte[]
            byte[] bytePassword = new byte[password.Length * sizeof(char)];
            System.Buffer.BlockCopy(password.ToCharArray(), 0, bytePassword, 0, bytePassword.Length);

            // hashing
            byte[] hashedPassword = SHA256.Create().ComputeHash(bytePassword);

            // tranform hashed password from byte[] to string
            char[] tempChars = new char[hashedPassword.Length / sizeof(char)];
            System.Buffer.BlockCopy(hashedPassword, 0, tempChars, 0, hashedPassword.Length);
            return new string(tempChars);
        }
    }
}