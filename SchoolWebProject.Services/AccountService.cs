﻿using System;
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
        private GenericRepository<User> userRepository;
        private GenericRepository<LogInData> userLoginRepository;
        private GenericRepository<Role> rolesRepository;
        private IEmailSenderService emailService;

        public AccountService(ILogger logger, GenericRepository<User> inputRepository, GenericRepository<LogInData> inloginrepo, GenericRepository<Role>inputRoles)
            : base(logger)
        {
            this.userRepository = inputRepository;
            this.userLoginRepository = inloginrepo;
            this.rolesRepository = inputRoles;
            this.emailService = new EmailSenderService(logger, this);
        }

        public void GenerateUserLoginData(User user)
        {
            string userLogin = GenerateLogin(user), userPassword = GeneratePassword();
            SaveUserLoginData(user, userLogin, userPassword);
            string message = string.Format(Constants.EmailMessage + "\nЛогін: " + userLogin + "\nПароль: " + userPassword);
            emailService.SendMail(user.Email, message);
        }

        public User GetUser(string userName, string password)
        {
            Expression<Func<LogInData, bool>> getUserByLogin = user => user.Login == userName;
            LogInData loginData;
            loginData = this.userLoginRepository.Get(getUserByLogin);
            if (loginData == null) return null;
            if (this.CheckUser(loginData, password) && loginData != null)
            {
                Expression<Func<User, bool>> getUser = user => user.Id == loginData.UserId;
                return this.userRepository.Get(getUser);
            }
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

        public Dictionary<string, string> GetUserRaws(Constants.UserRoles role)
        {
            var permisions = new Dictionary<string, string>();
            switch (role)
            {
                case Constants.UserRoles.Admin:
                    permisions["Teachers"] = "teachers";
                    permisions["Subjects"] = "subjects";
                    permisions["Pupils"] = "pupils";
                    permisions["Groups"] = "groups";
                    permisions["Scheldule"] = "scheldule";
                    permisions["Diary"] = "diaryService";
                    permisions["Journal"] = "journal";
                    permisions["News"] = "newsService";
                    permisions["Contacts"] = "schoolService";
                    break;
                case Constants.UserRoles.Teacher:
                    permisions["Pupils"] = "pupils";
                    permisions["Groups"] = "groups";
                    permisions["Scheldule"] = "scheldule";
                    permisions["Journal"] = "journal";
                    permisions["News"] = "newsService";
                    permisions["Contacts"] = "schoolService";
                    break;
                case Constants.UserRoles.Pupil:
                    permisions["Diary"] = "diaryService";
                    permisions["Scheldule"] = "scheldule";
                    permisions["Journal"] = "journal";
                    permisions["News"] = "newsService";
                    permisions["Contacts"] = "schoolService";
                    break;
                case Constants.UserRoles.Parent:
                    permisions["Teachers"] = "teachers";
                    permisions["Scheldule"] = "scheldule";
                    permisions["Journal"] = "journal";
                    permisions["News"] = "newsService";
                    permisions["Contacts"] = "schoolService";
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

        private void SaveUserLoginData(User user, string login, string password)
        {
            string salt = CreateSalt();
            userLoginRepository.Add(new LogInData
            {
                Login = login,
                PasswordSalt = salt,
                PasswordHash = CreateHashPassword(password, salt),
                UserId = user.Id,
            });
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