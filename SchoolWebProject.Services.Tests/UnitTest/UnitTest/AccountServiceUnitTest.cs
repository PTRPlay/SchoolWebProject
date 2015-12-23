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
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iemailSender = new Mock<IEmailSenderService>();
            var accountService = new AccountService(logger.Object,iUnitOfWork.Object, iemailSender.Object);
            string inputPassword = "password";
            string salt = accountService.CreateSalt();

            // Act
            string hash = accountService.CreateHashPassword(inputPassword, salt);

            // Assert
            Assert.AreEqual(Constants.ByteArrayToString(SHA256.Create().ComputeHash(Constants.StringToByteArray(inputPassword + salt))), hash);
        }

        [TestMethod]
        public void GetRoleById_Is_Invoke_RoleRepository()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iemailSender = new Mock<IEmailSenderService>();
            var iRoleRepository = new Mock<IRepository<Role>>();
            var accountService = new AccountService(logger.Object, iUnitOfWork.Object, iemailSender.Object);
            iUnitOfWork.Setup(g => g.RoleRepository).Returns(iRoleRepository.Object as GenericRepository<Role>);

            // Act
            accountService.GetRoleById(1);

            // Assert
            iUnitOfWork.Verify(g => g.RoleRepository, Times.Once);
        }

        [TestMethod]
        public void GetUser_Getting_Right_User()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var iUserRepository = new Mock<IRepository<User>>();
            var iLogRepository = new Mock<IRepository<LogInData>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iemailSender = new Mock<IEmailSenderService>();
            var accountService = new AccountService(logger.Object, iUnitOfWork.Object, iemailSender.Object);
            var salt = accountService.CreateSalt();
            Expression<Func<LogInData, bool>> exp = i => i.Login == "login";
            testLogInData.PasswordSalt = salt;
            testLogInData.PasswordHash = accountService.CreateHashPassword("password", salt);
            iUnitOfWork.Setup(st => st.LogInDataRepository).Returns(iLogRepository.Object as GenericRepository<LogInData>);
            iUnitOfWork.Setup(st => st.UserRepository).Returns(iUserRepository.Object as GenericRepository<User>);
            iLogRepository.Setup(i => i.Get(It.Is<Expression<Func<LogInData, bool>>>(y => y == exp))).Returns(testLogInData);
            iUserRepository.Setup(i => i.GetById(It.Is<int>(y => y == testLogInData.UserId))).Returns(testUser);

            // Act
            User result = accountService.GetUser("login", "password");

            // Assert
            Assert.AreEqual(result, testUser);
        }

        [TestMethod]
        public void GetUser_Is_Invoke_Repository()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var iUserRepository = new Mock<IRepository<User>>();
            var iLogRepository = new Mock<IRepository<LogInData>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iemailSender = new Mock<IEmailSenderService>();
            var accountService = new AccountService(logger.Object, iUnitOfWork.Object, iemailSender.Object);
            var salt = accountService.CreateSalt();
            Expression<Func<LogInData, bool>> exp = i => i.Login == "login";
            testLogInData.PasswordSalt = salt;
            testLogInData.PasswordHash = accountService.CreateHashPassword("password", salt);
            //iUnitOfWork.Setup(st => st.LogInDataRepository).Returns(iLogRepository.Object as GenericRepository<LogInData>);
            iUnitOfWork.Setup(st => st.UserRepository).Returns(iUserRepository.Object as GenericRepository<User>);
            iLogRepository.Setup(i => i.Get(e => e.Login == "login")).Returns(testLogInData);
            iUserRepository.Setup(i => i.GetById(It.Is<int>(y => y == testLogInData.UserId))).Returns(testUser);
            
            // Act
            accountService.GetUser("login", "password");
            
            // Assert
          //   iUserRepository.Verify(g => g.GetById(testLogInData.UserId), Times.Once);
            iUnitOfWork.Verify(g => g.LogInDataRepository, Times.Once);
        }

        
    }
}
