using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;


namespace UnitTest
{
    [TestClass]
    public class TeacherDegreeUnitTest
    {
        
        private static List<ViewTeacher> teachers = new List<ViewTeacher>
        {
            new ViewTeacher { LastName = "Соколовський", FirstName = "Дмитро", MiddleName = "Лютерович", 
                        PhoneNumber = "191119101"},
            new ViewTeacher { LastName = "Порковський", FirstName = "Леонід", MiddleName = "Лютерович", 
                        PhoneNumber = "191119101"}
        };


        private ViewTeacherDegree teacherDegree = new ViewTeacherDegree
        {
            Name = "Найнайстарший викладач"
        };

        [TestMethod]
        public void TeacherDegree_Get_Test_If_Get_All_TeacherCategories_And_Invoke_GetAll_repository_Method()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepository = new Mock<IRepository<TeacherDegree>>();
            iUnitOfWork.Setup(st => st.TeacherDegreeRepository).Returns(iRepository.Object);
            var teacherDegreeService = new TeacherDegreeService(logger.Object, iUnitOfWork.Object);
            //Act
            teacherDegreeService.GetAllTeacherDegrees();
            //Assert
            iRepository.Verify(inv => inv.GetAll(), Times.Once);
        }

        [TestMethod]
        public void TeacherDegree_GetById_Test_Is_Invoke_Repo_GetById()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<TeacherDegree>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            iUnitOfWork.Setup(st => st.TeacherDegreeRepository).Returns(iRepository.Object);
            AutoMapper.Mapper.CreateMap<ViewTeacherDegree, TeacherDegree>();
            var viewModel = AutoMapper.Mapper.Map<ViewTeacherDegree, TeacherDegree>(this.teacherDegree);
            iRepository.Setup(inv => inv.GetById(It.Is<int>(i => i > 0))).Returns(viewModel);
            var teacherDegreeService = new TeacherDegreeService(logger.Object, iUnitOfWork.Object);
            int anyIdMoreZero = 2;
            //Act
            teacherDegreeService.GetTeacherDegreeById(anyIdMoreZero);
            //Assert
            iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TeacherDegree_GetById_Test_Is_Generete_Exeption_If_Id_less_zero()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<TeacherDegree>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            AutoMapper.Mapper.CreateMap<ViewTeacherDegree, TeacherDegree>();
            var viewModel = AutoMapper.Mapper.Map<ViewTeacherDegree, TeacherDegree>(this.teacherDegree);
            iUnitOfWork.Setup(st => st.TeacherDegreeRepository).Returns(iRepository.Object);
            var teacherDegreeService = new TeacherDegreeService(logger.Object, iUnitOfWork.Object);
            int anyIdLessZero = -5;
            //Act
            var tempteacherDegree = teacherDegreeService.GetTeacherDegreeById(anyIdLessZero);
        }

        [TestMethod]
        public void TeacherDegree_Update_Degree_Method() 
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<TeacherDegree>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            iUnitOfWork.Setup(st => st.TeacherDegreeRepository).Returns(iRepository.Object);
            AutoMapper.Mapper.CreateMap<ViewTeacherDegree, TeacherDegree>();
            var teacherDegreeService = new TeacherDegreeService(logger.Object, iUnitOfWork.Object);
            //Act
            teacherDegreeService.UpdateTeacherDegree(this.teacherDegree.Id, this.teacherDegree);
            //Assert
            iRepository.Verify(inv=>inv.Update(It.IsAny<TeacherDegree>()),Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TeacherDegree_Delete_Degree_Method_If_Id_Is_Null() 
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<TeacherDegree>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            iUnitOfWork.Setup(st => st.TeacherDegreeRepository).Returns(iRepository.Object);
            var teacherDegreeService = new TeacherDegreeService(logger.Object, iUnitOfWork.Object);
            AutoMapper.Mapper.CreateMap<ViewTeacherDegree, TeacherDegree>();
            var teacherDegree = AutoMapper.Mapper.Map<ViewTeacherDegree, TeacherDegree>(this.teacherDegree);
            //Act
            teacherDegreeService.DeleteTeacherDegree(this.teacherDegree.Id);
        }

        [TestMethod]
        public void TeacherDegree_AddUnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepositoryHolidays = new Mock<IRepository<TeacherDegree>>();

            iUnitOfWork.Setup(st => st.TeacherDegreeRepository).Returns(iRepositoryHolidays.Object);
            var teacherDegreeService = new TeacherDegreeService(logger.Object, iUnitOfWork.Object);
            AutoMapper.Mapper.CreateMap<ViewTeacherDegree, TeacherDegree>();
            //Act
            teacherDegreeService.AddTeacherDegree(this.teacherDegree);
            //Assert
            iRepositoryHolidays.Verify(inv => inv.Add(It.IsAny<TeacherDegree>()), Times.Once);
        }
    }
}
