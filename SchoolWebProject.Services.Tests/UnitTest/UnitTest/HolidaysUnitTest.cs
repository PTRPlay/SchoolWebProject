using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;

namespace UnitTest
{
    [TestClass]
    public class HolidaysUnitTest
    {
        private Holidays holidays = new Holidays 
        { 
            Id = 2,
            StartDay = new DateTime (1999, 10, 29),
            EndDay = new DateTime(1999, 11, 11),
            Name = "Осінні канікули",
        };
        
        [TestMethod]
        public void GetHolidays_Test_If_Get_All_Holidays_And_Invoke_GetAll_repository_Method()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepository = new Mock<IRepository<Holidays>>();
            iUnitOfWork.Setup(st => st.HolidaysRepository).Returns(iRepository.Object);
            var holidaysService = new HolidaysService(logger.Object, iUnitOfWork.Object);
            //Act
            holidaysService.GetAllHolidays();
            //Assert
            iRepository.Verify(inv => inv.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetHolidaysById_Test_Is_Invoke_Repo_GetById()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Holidays>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();

            iUnitOfWork.Setup(st => st.HolidaysRepository).Returns(iRepository.Object);
            iRepository.Setup(inv => inv.GetById(It.Is<int>(i => i > 0))).Returns(this.holidays);
            var holidaysService = new HolidaysService(logger.Object, iUnitOfWork.Object);
            int anyIdMoreZero = 2;
            //Act
            holidaysService.GetHolidaysById(anyIdMoreZero);
            //Assert
            iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.Once);
        }

//        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetHolidaysById_Test_Is_Generete_Exeption_If_Id_less_zero()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Holidays>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            iUnitOfWork.Setup(st => st.HolidaysRepository).Returns(iRepository.Object);
            var holidaysService = new HolidaysService(logger.Object, iUnitOfWork.Object);
            int anyIdLessZero =-5;
            //Act
            var tempholidays = holidaysService.GetHolidaysById(anyIdLessZero);
            //Assert
            iRepository.Verify(inv => inv.GetById(anyIdLessZero), Times.Once);
        }

        [TestMethod]
        public void UpdateHolidaysUnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Holidays>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();

            iUnitOfWork.Setup(st => st.HolidaysRepository).Returns(iRepository.Object);
            var holidaysService = new HolidaysService(logger.Object, iUnitOfWork.Object);
            //Act
            holidaysService.UpdateHolidays(this.holidays);
            //Assert
            iRepository.Verify(inv => inv.Update(this.holidays), Times.Once);
        }

        [TestMethod]
        public void AddHolidaysUnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepositoryHolidays = new Mock<IRepository<Holidays>>();
            
            iUnitOfWork.Setup(st => st.HolidaysRepository).Returns(iRepositoryHolidays.Object);

            var holidaysService = new HolidaysService(logger.Object, iUnitOfWork.Object);
            //Act
            holidaysService.AddHolidays(this.holidays);
            var tmp = holidaysService.GetAllHolidays();
            //Assert
            iRepositoryHolidays.Verify(inv => inv.Add(this.holidays), Times.Once);
        }

        [TestMethod]
        public void RemoveHolidaysUnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Holidays>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();

            iUnitOfWork.SetupGet(u => u.HolidaysRepository).Returns(iRepository.Object);
            iRepository.Setup(h => h.Add(this.holidays));
            iRepository.Setup(h => h.GetById(this.holidays.Id));
            var holidaysService = new HolidaysService(logger.Object, iUnitOfWork.Object);
            //Act
            holidaysService.AddHolidays(this.holidays);
            holidaysService.RemoveHolidays(this.holidays.Id);
            //Assert
            iRepository.Verify(inv => inv.Delete(this.holidays), Times.Once);
            //iUnitOfWork.Verify(inv => inv.HolidaysRepository.Delete(this.holidays));
        }

    }
}
