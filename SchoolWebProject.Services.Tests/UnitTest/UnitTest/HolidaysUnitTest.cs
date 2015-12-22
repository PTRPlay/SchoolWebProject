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
            StartDay = new DateTime (1999, 10, 29),
            EndDay = new DateTime(1999, 11, 11),
            Name = "Осінні канікули"
        };
        
        [TestMethod]
        public void TestMethod1()
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
    }
}
