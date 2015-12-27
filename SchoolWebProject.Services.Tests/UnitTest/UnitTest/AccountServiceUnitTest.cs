using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;

namespace UnitTest
{
    [TestClass]
    public class AccountServiceUnitTest
    {
        private User testUser = new Teacher()
        {
            FirstName = "testFirst",
            LastName = "testLast",
            RoleId = 2,
            Id = 1
        };

        private LogInData testLogInData = new LogInData()
        {
            Login = "login",
            UserId = 1,
        };

        [TestMethod]
        public void CreateHashPassword_Is_Right_Hashing()
        {
            // Arrange
            var accountService = this.Initialize(testLogInData, testUser);
            string inputPassword = "password";
            string salt = accountService.CreateSalt();

            // Act
            string hash = accountService.CreateHashPassword(inputPassword, salt);

            // Assert
            Assert.AreEqual(Constants.ByteArrayToString(SHA256.Create().ComputeHash(Constants.StringToByteArray(inputPassword + salt))), hash);
        }

        [TestMethod]
        public void GetRoleById_Invoke_RoleRepository()
        {
            // Arrange
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRoleRepository = new Mock<IRepository<Role>>();
            var accountService = new AccountService(new Mock<ILogger>().Object, iUnitOfWork.Object);
            iUnitOfWork.Setup(g => g.RoleRepository).Returns(iRoleRepository.Object);
            int testId = 2;

            // Act
            accountService.GetRoleById(testId);

            // Assert
            iUnitOfWork.Verify(g => g.RoleRepository, Times.Once);
        }

        [TestMethod]
        public void GetRoleById_Not_Invoke_Repository_If_Null_Id()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var iemailSender = new Mock<IEmailSenderService>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRoleRepository = new Mock<IRepository<Role>>();
            var accountService = new AccountService(logger.Object, iUnitOfWork.Object);
            iUnitOfWork.Setup(g => g.RoleRepository).Returns(iRoleRepository.Object);
            int? testId = null;

            // Act
            Role result = accountService.GetRoleById(testId);

            // Assert
            iUnitOfWork.Verify(g => g.RoleRepository, Times.Never);
        }

        [TestMethod]
        public void GetUser_Getting_Right_User()
        {
            // Arrange
            var accountService = this.Initialize(testLogInData, testUser);
            string inputPassword = "password";
            testLogInData.PasswordSalt = accountService.CreateSalt();
            testLogInData.PasswordHash = accountService.CreateHashPassword(inputPassword, testLogInData.PasswordSalt);

            // Act
            User result = accountService.GetUser(testLogInData.Login, inputPassword);

            // Assert
            Assert.AreEqual(testUser, result);
        }

        [TestMethod]
        public void GetUser_Returns_Null_If_Wrong_Password()
        {
            // Arrange 
            var accountService = this.Initialize(testLogInData, testUser);
            string rightPassword = "password";
            string wrongPassword = "wrongPassword";
            testLogInData.PasswordSalt = accountService.CreateSalt();
            testLogInData.PasswordHash = accountService.CreateHashPassword(rightPassword, testLogInData.PasswordSalt);

            // Act
            User result = accountService.GetUser(testLogInData.Login, wrongPassword);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUserRaws_Returns_Null_If_Role_None()
        {
            // Arrange
            var accountService = this.Initialize(testLogInData, testUser);

            // Act
            var raws = accountService.GetUserRaws(Constants.UserRoles.None);

            // Assert
            Assert.IsNull(raws);
        }

        // sometimes falls with FormatException(dont know why)
        [TestMethod]
        public void GenerateUserLoginData_Do_Send_Mail() 
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iemailSender = new Mock<IEmailSenderService>();
            var accountService = new AccountService(logger.Object, iUnitOfWork.Object);

            // Act
            var result = accountService.GenerateUserLoginData(testUser);

            // Assert
            iemailSender.Verify(s => s.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        private AccountService Initialize(LogInData testLogin, User testUser)
        {
            var logger = new Mock<ILogger>();
            var iUserRepository = new Mock<IRepository<User>>();
            var iLogRepository = new Mock<IRepository<LogInData>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iemailSender = new Mock<IEmailSenderService>();
            iUnitOfWork.Setup(st => st.LogInDataRepository).Returns(iLogRepository.Object);
            iUnitOfWork.Setup(st => st.UserRepository).Returns(iUserRepository.Object);
            iLogRepository.Setup(i => i.Get(It.IsAny<Expression<Func<LogInData, bool>>>())).Returns(testLogin);
            iUserRepository.Setup(i => i.GetById(It.Is<int>(y => y == testLogin.UserId))).Returns(testUser);
            return new AccountService(logger.Object, iUnitOfWork.Object);
        }
    }
}
