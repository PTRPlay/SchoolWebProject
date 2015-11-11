using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolWebProject.Services;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using Moq;
using System.Collections.Generic;
namespace SchoolWebProject.UnitTestProject
{
    [TestClass]
    public class TeacherServiceUnitTest
    {
        List<Teacher> teachers = new List<Teacher> {
                new Teacher { LastName = "Бойченко", FirstName = "Ярослава", MiddleName = "Станіславівна", 
    WorkBegin = new DateTime(1998, 6, 21), PhoneNumber = "693984558", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Гарланенко", FirstName = "Євгенія", MiddleName = "Сергіївна", 
    WorkBegin = new DateTime(2008, 3, 18), PhoneNumber = "993385320", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Євенко", FirstName = "Вадим", MiddleName = "Олегович", 
    WorkBegin = new DateTime(1990, 7, 18), PhoneNumber = "290849203", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
 };

        [TestMethod]
        public void GetTeachers_Test_If_Get_All_Teacher_And_Invoke_GetAll_repository_Method()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var teacherService = new TeacherService(logger.Object);
            iRepository.Setup(act => act.GetAll()).Returns(teachers);

            var expacted = teachers.Count;
            var actual = teacherService.GetAllTeachers();

            iRepository.Verify(inv => inv.GetAll(), Times.Once);
            Assert.AreEqual(expacted, actual);


        }

        [TestMethod]
        public void GetProfileById_Test_Is_Return_One_Profile()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            iRepository.Setup(inv => inv.GetById(It.Is<int>(i => i > 0))).Returns(new Teacher { Id = 2, FirstName = "fn", LastName = "ln" });

            var teacherService = new TeacherService(logger.Object);
            int anyIdMoreZero = 0;

            var teacher = teacherService.GetProfileById(anyIdMoreZero);

            iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.AtLeastOnce);
            Assert.IsNotNull(teacher);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetProfileById_Test_Is_Generete_Exeption_If_Id_less_zero()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var teacherService = new TeacherService(logger.Object);
            int anyIdMoreZero = -2;
            var teacher = teacherService.GetProfileById(anyIdMoreZero);
            iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.AtLeastOnce);
        }

        [TestMethod]
        public void UpdateProfileUnitTest()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var teacherService = new TeacherService(logger.Object);
            Teacher teacher = new Teacher
            {
                LastName = "Nikon",
                FirstName = "Вадим",
                MiddleName = "Олегович",
                WorkBegin = new DateTime(1990, 7, 18),
                PhoneNumber = "290849203",
                RoleId = 2,
                SchoolId = 1,
                TeacherCategoryId = 2
            };
            teacherService.UpdateProfile(teacher);

            iRepository.Verify(inv => inv.Update(teacher), Times.Once);
        }

        [TestMethod]
        public void AddTeacherUnitTest()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var teacherService = new TeacherService(logger.Object);
            Teacher teacher = new Teacher
            {
                LastName = "Nikon",
                FirstName = "Вадим",
                MiddleName = "Олегович",
                WorkBegin = new DateTime(1990, 7, 18),
                PhoneNumber = "290849203",
                RoleId = 2,
                SchoolId = 1,
                TeacherCategoryId = 2
            };
            teacherService.AddTeacher(teacher);
            iRepository.Verify(inv => inv.Add(teacher), Times.Once);
        }

        [TestMethod]
        public void RemoveTeacherUnit5Test()
        {
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Teacher>>();
            var teacherService = new TeacherService(logger.Object);
            Teacher teacher = new Teacher
            {
                LastName = "Nikon",
                FirstName = "Вадим",
                MiddleName = "Олегович",
                WorkBegin = new DateTime(1990, 7, 18),
                PhoneNumber = "290849203",
                RoleId = 2,
                SchoolId = 1,
                TeacherCategoryId = 2
            };
            teacherService.RemoveTeacher(teacher);

            iRepository.Verify(inv => inv.Delete(teacher), Times.Once);
        }

    }
}
