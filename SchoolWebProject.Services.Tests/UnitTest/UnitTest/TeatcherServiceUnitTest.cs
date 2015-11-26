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
      private List<Teacher> teachers = new List<Teacher> 
      {
          new Teacher 
          { 
              LastName = "Бойченко", FirstName = "Ярослава", MiddleName = "Станіславівна",
              WorkBegin = new DateTime(1998, 6, 21), PhoneNumber = "693984558", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 
          },
          new Teacher 
          {
              LastName = "Гарланенко", FirstName = "Євгенія", MiddleName = "Сергіївна",
              WorkBegin = new DateTime(2008, 3, 18), PhoneNumber = "993385320", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 
          },
          new Teacher 
          {
              LastName = "Євенко", FirstName = "Вадим", MiddleName = "Олегович",
              WorkBegin = new DateTime(1990, 7, 18), PhoneNumber = "290849203", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2
          },
 };

      private Teacher teacher = new Teacher 
      {
          LastName = "Бойченко", FirstName = "Ярослава", MiddleName = "Станіславівна",
          WorkBegin = new DateTime(1998, 6, 21), PhoneNumber = "693984558", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 
      };

        [TestMethod]
        public void GetTeachers_Test_If_Get_All_Teacher_And_Invoke_GetAll_repository_Method()
        {
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            iUnitOfWork.Setup(inv => inv.TeacherRepository.GetAll());

            teacherService.GetAllTeachers();

            iUnitOfWork.Verify(inv => inv.TeacherRepository.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetProfileById_Test_Is_Invoke_Repo_GetById()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            iRepository.Setup(inv => inv.GetById(It.Is<int>(i => i > 0))).Returns(this.teacher);
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            int anyIdMoreZero = 3;

           teacherService.GetProfileById(anyIdMoreZero);
            
           iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetProfileById_Test_Is_Generete_Exeption_If_Id_less_zero()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);
            int anyIdMoreZero = -2;

            var teacher = teacherService.GetProfileById(anyIdMoreZero);

            iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.Once);
        }

        [TestMethod]
        public void UpdateProfileUnitTest()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);

            teacherService.UpdateProfile(this.teacher);

            iRepository.Verify(inv => inv.Update(this.teacher), Times.Once);
        }

        [TestMethod]
        public void AddTeacherUnitTest()
        {
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);

            teacherService.AddTeacher(this.teacher);

            iUnitOfWork.Verify(inv => inv.TeacherRepository.Add(this.teacher), Times.Once);
        }

        [TestMethod]
        public void RemoveTeacherUnit5Test()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var teacherService = new TeacherService(logger.Object, iUnitOfWork.Object);

            teacherService.RemoveTeacher(this.teacher);

            iRepository.Verify(inv => inv.Delete(this.teacher), Times.Once);
        }
    }
}
