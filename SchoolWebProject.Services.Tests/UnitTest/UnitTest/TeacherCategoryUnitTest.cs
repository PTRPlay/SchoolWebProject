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
    public class TeacherCategoryUnitTest
    {
        
        private static List<ViewTeacher> teachers = new List<ViewTeacher>
        {
            new ViewTeacher { LastName = "Соколовський", FirstName = "Дмитро", MiddleName = "Лютерович", 
                        PhoneNumber = "191119101"},
            new ViewTeacher { LastName = "Порковський", FirstName = "Леонід", MiddleName = "Лютерович", 
                        PhoneNumber = "191119101"}
        };


        private ViewTeacherCategory teacherCategory = new ViewTeacherCategory
        {
            Name = "Директор спеціалістів"

        };

        [TestMethod]
        public void TeacherCategory_Get_Test_If_Get_All_TeacherCategories_And_Invoke_GetAll_repository_Method()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepository = new Mock<IRepository<TeacherCategory>>();
            iUnitOfWork.Setup(st => st.TeacherCategoryRepository).Returns(iRepository.Object);
            var teacherCategoryService = new TeacherCategoryService(logger.Object, iUnitOfWork.Object);
            //Act
            teacherCategoryService.GetAllTeacherCategories();
            //Assert
            iRepository.Verify(inv => inv.GetAll(), Times.Once);
        }

        [TestMethod]
        public void TeacherCategory_GetById_Test_Is_Invoke_Repo_GetById()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<TeacherCategory>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            iUnitOfWork.Setup(st => st.TeacherCategoryRepository).Returns(iRepository.Object);
            AutoMapper.Mapper.CreateMap<ViewTeacherCategory, TeacherCategory>();
            var viewModel = AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(this.teacherCategory);
            iRepository.Setup(inv => inv.GetById(It.Is<int>(i => i > 0))).Returns(viewModel);
            var teacherCategoryService = new TeacherCategoryService(logger.Object, iUnitOfWork.Object);
            int anyIdMoreZero = 2;
            //Act
            teacherCategoryService.GetTeacherCategoryById(anyIdMoreZero);
            //Assert
            iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TeacherCategory_GetById_Test_Is_Generete_Exeption_If_Id_less_zero()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<TeacherCategory>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            AutoMapper.Mapper.CreateMap<ViewTeacherCategory, TeacherCategory>();
            var viewModel = AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(this.teacherCategory);
            iUnitOfWork.Setup(st => st.TeacherCategoryRepository).Returns(iRepository.Object);
            var teacherCategoryService = new TeacherCategoryService(logger.Object, iUnitOfWork.Object);
            int anyIdLessZero = -5;
            //Act
            var tempteacherCategory = teacherCategoryService.GetTeacherCategoryById(anyIdLessZero);
            //Assert
            iRepository.Verify(inv => inv.GetById(anyIdLessZero), Times.Once);
        }

        [TestMethod]
        public void TeacherCategory_Update_Category_Method() 
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<TeacherCategory>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            iUnitOfWork.Setup(st => st.TeacherCategoryRepository).Returns(iRepository.Object);
            AutoMapper.Mapper.CreateMap<ViewTeacherCategory, TeacherCategory>();
            var teacherCategoryService = new TeacherCategoryService(logger.Object, iUnitOfWork.Object);
            //Act
            teacherCategoryService.UpdateTeacherCategory(this.teacherCategory.Id, this.teacherCategory);
            //Assert
            iRepository.Verify(inv=>inv.Update(It.IsAny<TeacherCategory>()),Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TeacherCategory_Delete_Category_Method_If_Id_Is_Null() 
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<TeacherCategory>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            iUnitOfWork.Setup(st => st.TeacherCategoryRepository).Returns(iRepository.Object);
            var teacherCategoryService = new TeacherCategoryService(logger.Object, iUnitOfWork.Object);
            AutoMapper.Mapper.CreateMap<ViewTeacherCategory, TeacherCategory>();
            var teacherCategory = AutoMapper.Mapper.Map<ViewTeacherCategory, TeacherCategory>(this.teacherCategory);
            //Act
            teacherCategoryService.DeleteTeacherCategory(this.teacherCategory.Id);
        }

        [TestMethod]
        public void TeacherCategory_AddUnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepositoryHolidays = new Mock<IRepository<TeacherCategory>>();

            iUnitOfWork.Setup(st => st.TeacherCategoryRepository).Returns(iRepositoryHolidays.Object);
            var teacherCategoryService = new TeacherCategoryService(logger.Object, iUnitOfWork.Object);
            AutoMapper.Mapper.CreateMap<ViewTeacherCategory, TeacherCategory>();
            //Act
            teacherCategoryService.AddTeacherCategory(this.teacherCategory);
            //Assert
            iRepositoryHolidays.Verify(inv => inv.Add(It.IsAny<TeacherCategory>()), Times.Once);
        }

    }
}
