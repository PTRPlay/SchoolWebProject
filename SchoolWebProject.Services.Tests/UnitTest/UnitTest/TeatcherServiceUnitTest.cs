using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;

namespace SchoolWebProject.UnitTestProject
{
    [TestClass]
    public class TeacherServiceUnitTest
    {
      private List<Subject> subjects = new List<Subject>
      {
          new Subject { Name = "хімія", Teachers=new List<Teacher>() },//1
          new Subject { Name = "фізика", Teachers=new List<Teacher>() },//2
          new Subject { Name = "математика", Teachers=new List<Teacher>() }//3
      };

      private Teacher teacher = new Teacher 
      {
          LastName = "Бойченко", FirstName = "Ярослава", MiddleName = "Станіславівна", Subjects=new List<Subject>(),
          WorkBegin = new DateTime(1998, 6, 21), PhoneNumber = "693984558", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 
      };

        [TestMethod]
        public void GetTeachers_Test_If_Get_All_Teacher_And_Invoke_GetAll_repository_Method()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepository = new Mock<IRepository<Teacher>>();

            iUnitOfWork.Setup(st => st.TeacherRepository).Returns(iRepository.Object);
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            //Act
            teacherService.GetAllTeachers();
            //Assert
            iRepository.Verify(inv => inv.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetProfileById_Test_Is_Invoke_Repo_GetById()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();

            iUnitOfWork.Setup(st => st.TeacherRepository).Returns(iRepository.Object);
            iRepository.Setup(inv => inv.GetById(It.Is<int>(i => i > 0))).Returns(this.teacher);
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            int anyIdMoreZero = 3;
            //Act
           teacherService.GetProfileById(anyIdMoreZero);
            //Assert
           iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetProfileById_Test_Is_Generete_Exeption_If_Id_less_zero()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();

            iUnitOfWork.Setup(st => st.TeacherRepository).Returns(iRepository.Object);
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            int anyIdLessZero = -2;
            //Act
            var teacher = teacherService.GetProfileById(anyIdLessZero);
            //Assert
            iRepository.Verify(inv => inv.GetById(anyIdLessZero), Times.Once);
        }

        [TestMethod]
        public void UpdateProfileUnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();

            iUnitOfWork.Setup(st => st.TeacherRepository).Returns(iRepository.Object);
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            //Act
            teacherService.UpdateProfile(this.teacher);
            //Assert
            iRepository.Verify(inv => inv.Update(this.teacher), Times.Once);
        }

        [TestMethod]
        public void AddTeacherUnitTest()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepositoryTeacher = new Mock<IRepository<Teacher>>();
            var iRepositorySubject = new Mock<IRepository<Subject>>();


            this.teacher.Subjects = this.subjects;
            iUnitOfWork.Setup(st => st.TeacherRepository).Returns(iRepositoryTeacher.Object);
            iUnitOfWork.Setup(st => st.SubjectRepository).Returns(iRepositorySubject.Object);
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            //Act
            teacherService.AddTeacher(this.teacher);
            //Assert
           iRepositoryTeacher.Verify(inv => inv.Add(this.teacher), Times.Once);
        }

        [TestMethod]
        public void RemoveTeacherUnit5Test()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            iUnitOfWork.SetupGet(u => u.TeacherRepository).Returns(iRepository.Object);
            //Act
            teacherService.RemoveTeacher(this.teacher);
            //Assert
            iRepository.Verify(inv => inv.Delete(this.teacher), Times.Once);
        }
    }
}
