using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
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
    public class ParentServiceUnitTest
    {

        private static List<Pupil> pupils = new List<Pupil>
        {
            new Pupil { LastName = "Соколовський", FirstName = "Дмитро", MiddleName = "Лютерович", 
                        PhoneNumber = "191119101", RoleId = 3, SchoolId = 1, GroupId = 2 },
            new Pupil { LastName = "Порковський", FirstName = "Леонід", MiddleName = "Лютерович", 
                        PhoneNumber = "191119101", RoleId = 3, SchoolId = 1, GroupId = 2 }
        };

        private int pageNumb = 2; 
        
        private int amount = 20; 
        
        private string sorting = "LastName"; 
        
        private string filtering; 
        
        private int pageCount = 3;
        
        Parent parent = new Parent 
        {
            LastName = "Мартін",
            FirstName = "Лютер",
            MiddleName = "Кінг",
            PhoneNumber = "1021021222",
            Address = "New York", 
            Email = "i_have@dream.com",
            RoleId = 4,
            SchoolId = 1,
            Pupils = pupils
        };

        [TestMethod]
        public void Parents_Get_Test_If_Get_All_Teacher_And_Invoke_GetAll_repository_Method()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepository = new Mock<IRepository<Parent>>();
            iUnitOfWork.Setup(st => st.ParentRepository).Returns(iRepository.Object);
            var teacherService = new ParentService(logger.Object, iUnitOfWork.Object);
            //Act
            teacherService.GetAllParents();
            //Assert
            iRepository.Verify(inv => inv.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Parent_UpdateProfileUnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Parent>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            
            iUnitOfWork.Setup(st => st.ParentRepository).Returns(iRepository.Object);
            var parentService = new ParentService(logger.Object, iUnitOfWork.Object);
            //Act
            parentService.UpdateParent(this.parent);
            //Assert
            iRepository.Verify(inv => inv.Update(this.parent), Times.Once);
        }

        [TestMethod]
        public void Parent_Delete_UnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Parent>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();

            iUnitOfWork.Setup(st => st.ParentRepository).Returns(iRepository.Object);
            var parentService = new ParentService(logger.Object, iUnitOfWork.Object);
            //Act
            parentService.RemoveParent(this.parent.Id);
            //Assert
            iRepository.Verify(inv => inv.Delete(It.IsAny<Parent>()), Times.Once);
        }

        [TestMethod]
        public void Parent_GetPage_Method()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepository = new Mock<IRepository<Parent>>();
            iUnitOfWork.Setup(st => st.ParentRepository).Returns(iRepository.Object);
            var parentService = new ParentService(logger.Object, iUnitOfWork.Object);
            parentService.AddParent(this.parent);
            //Act
            parentService.GetPage(pageNumb, amount, sorting, filtering, out pageCount);
            //Assert
            iRepository.Verify(inv => inv.GetAll(), Times.Once);
            
        }

    }
}
