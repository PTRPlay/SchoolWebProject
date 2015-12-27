using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Interfaces;
using sModels = SchoolWebProject.Services.Models;

namespace UnitTest
{
    [TestClass]
    public class PupilServiceUnitTest
    {
        private Pupil pupil = new Pupil
              {
                  Id = 30,
                  LastName = "Поттер",
                  FirstName = "Гаррі",
                  MiddleName = "Джеймс",
                  PhoneNumber = "693984558",
                  Address = "London",
                  Email = "hp@gmail.com",
                  RoleId = 3,
                  SchoolId = 1,
                  GroupId = 3,
                  Group = new Group { Id = 3 }
              };

        private sModels.ViewPupil viewPupil = new sModels.ViewPupil
            {
                Id = 3,
                FirstName = "Jack",
                LastName = "Berton",
                MiddleName = "Jaimes",
                PhoneNumber = "98787655",
                Email = "somemail@mail.com",
                GroupId = 1,
                GroupLetter = "А",
                GroupNumber = "1"
            };

        [TestMethod]
        public void GetPupil_Test_If_Get_All_Pupil_And_Invoke_GetAll_repository_Method()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iPupilRepository = new Mock<IRepository<Pupil>>();
            var iAccountService = new Mock<IAccountService>();
            var iGroupService = new Mock<IGroupService>();

            iUnitOfWork.Setup(st => st.PupilRepository).Returns(iPupilRepository.Object);
            var pupilService = new PupilService(logger.Object, iUnitOfWork.Object, iAccountService.Object, iGroupService.Object);
            //Act
            pupilService.GetAllPupils();
            //Assert
            iPupilRepository.Verify(inv => inv.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetProfileById_Test_Is_Invoke_Repo_GetById()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iPupilRepository = new Mock<IRepository<Pupil>>();
            var iAccountService = new Mock<IAccountService>();
            var iGroupService = new Mock<IGroupService>();

            iUnitOfWork.Setup(st => st.PupilRepository).Returns(iPupilRepository.Object);
            iPupilRepository.Setup(inv => inv.GetById(It.Is<int>(i => i > 0))).Returns(this.pupil);
            var pupilService = new PupilService(logger.Object, iUnitOfWork.Object, iAccountService.Object, iGroupService.Object);

            int anyIdMoreZero = 3;
            //Act
            pupilService.GetProfileById(anyIdMoreZero);
            //Assert
            iPupilRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetProfileById_Test_Is_Generete_Exeption_If_Id_less_zero()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iPupilRepository = new Mock<IRepository<Pupil>>();
            var iAccountService = new Mock<IAccountService>();
            var iGroupService = new Mock<IGroupService>();

            iUnitOfWork.Setup(st => st.PupilRepository).Returns(iPupilRepository.Object);
            var pupilService = new PupilService(logger.Object, iUnitOfWork.Object, iAccountService.Object, iGroupService.Object);
            int anyIdLessZero = -2;
            //Act
            var teacher = pupilService.GetProfileById(anyIdLessZero);
            //Assert
            iPupilRepository.Verify(inv => inv.GetById(anyIdLessZero), Times.Once);
        }

        [TestMethod]
        public void RemovePupilUnit5Test()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Pupil>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iAccountService = new Mock<IAccountService>();
            var iGroupService = new Mock<IGroupService>();

            var pupilService = new PupilService(logger.Object, iUnitOfWork.Object, iAccountService.Object, iGroupService.Object);
            iUnitOfWork.SetupGet(u => u.PupilRepository).Returns(iRepository.Object);
            //Act
            pupilService.RemovePupil(this.pupil.Id);
            //Assert
            iRepository.Verify(inv => inv.Delete(this.pupil), Times.Once);
            
        }
    }
}



