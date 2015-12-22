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

namespace UnitTest
{
    [TestClass]
    public class PupilServiceUnitTest
    {
        private Pupil pupil = new Pupil
              {
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

        [TestMethod]
        public void GetPupil_Test_If_Get_All_Pupil_And_Invoke_GetAll_repository_Method()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepository = new Mock<IRepository<Pupil>>();
            var iAccountService = new Mock<IAccountService>();
            var iGroupService = new Mock<IGroupService>();

            iUnitOfWork.Setup(st => st.PupilRepository).Returns(iRepository.Object);
            var pupilService = new PupilService(logger.Object, iUnitOfWork.Object, iAccountService.Object, iGroupService.Object);
            //Act
            pupilService.GetAllPupils();
            //Assert
            iRepository.Verify(inv => inv.GetAll(), Times.Once);
        }

        
    }
}



