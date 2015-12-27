using System;
using System.Collections.Generic;
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
    public class AnnouncementServiceUnitTest
    {
        private List<Announcement> announcements = new List<Announcement>
      {
                new Announcement
                {
                    Title = "І етап адаптаційних занять для майбутніх першокласників",
                    Message = "Оголошуємо набір учнів у 1-ий клас на 2016-2017 н.р.",
                    MessageDetails = "Вітаємо всіх учасників навчально-виховного процесу, особливо батьків та малюків, що сьогодні відвідали перші заняття!",
                    DataPublished = new DateTime(2015, 9, 11),
                    Image = "some image in base64 format",
                    SchoolId = 1
                },
                 new Announcement
                {
                    Title = "День учнівського самоврядування",
                    Message = "Сьогодні в школі відбувся День учнівського самоврядування. Захід проводився з метою пропагування серед учнівської молоді основних засад місцевого самоврядування",
                    MessageDetails = "У Дні учнівського самоврядування взяли участь учні 9-11-х класів та лідери Учнівського парламенту.",
                    DataPublished = new DateTime(2015, 10, 2),
                    Image="some image in base64 format",
                    SchoolId = 1
                },
                 new Announcement
                {
                    Title = "Виставка малюнків - Золота Осінь",
                    Message = "Сьогодні відбулась загальношкільна виставка малюнків учнів. У конкурсі приймали участь діти молодшої школи. Їхні малюнки розповідають про неповторну чарівність золотої осені.  ",
                    DataPublished = new DateTime(2015, 10, 9),
                    Image = "some image in base64 format",
                    SchoolId = 1
                },
                new Announcement
                {
                    Title = "Святий Миколай іде до сиріт",
                    Message = "Багато років поспіль, ще задовго до свята Миколая, Мальтійська Служба Допомоги на початку листопада розпочинає традиційну акцію.",
                    MessageDetails = "Метою акції є приготування подарунків дітям та сиротам, які проживають в інтернатах і дитячих будинках Івано-Франківська та області до дня Святого Миколая",
                    DataPublished = new DateTime(2015, 11, 19),
                    Image = "some image in base64 format",
                    SchoolId = 1
                }  
      };

        private Announcement announcement = new Announcement
        {
            Title = "І етап адаптаційних занять для майбутніх першокласників",
            Message = "Оголошуємо набір учнів у 1-ий клас на 2016-2017 н.р.",
            MessageDetails = "Вітаємо всіх учасників навчально-виховного процесу, особливо батьків та малюків, що сьогодні відвідали перші заняття!",
            DataPublished = new DateTime(2015, 9, 11),
            Image = "some image in base64 format",
            SchoolId = 1
        };

        private ViewAnnouncement viewannouncement = new ViewAnnouncement
        {
            Title = "І етап адаптаційних занять для майбутніх першокласників",
            Message = "Оголошуємо набір учнів у 1-ий клас на 2016-2017 н.р.",
            MessageDetails = "Вітаємо всіх учасників навчально-виховного процесу, особливо батьків та малюків, що сьогодні відвідали перші заняття!",
            DataPublished = new DateTime(2015, 9, 11),
            Image = "some image in base64 format"
        };

        [TestMethod]
        public void GetAllAnnouncements_Test_If_Get_All_Announcement_Invoke_repository_GetAll()
        {
            //Arange
            var logger = new Mock<ILogger>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            var iRepository = new Mock<IRepository<Announcement>>();
            iUnitOfWork.Setup(st => st.AnnouncementRepository).Returns(iRepository.Object);
            var announcementService = new AnnouncementService(logger.Object, iUnitOfWork.Object);
            //Act
            announcementService.GetAllAnnouncements();
            //Assert
            iRepository.Verify(inv => inv.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetAnnouncementById_Test_Is_Invoke_repository_GetById()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var iRepository = new Mock<IRepository<Announcement>>();
            var iUnitOfWork = new Mock<IUnitOfWork>();
            iUnitOfWork.Setup(st => st.AnnouncementRepository).Returns(iRepository.Object);
            var announcementService = new AnnouncementService(logger.Object, iUnitOfWork.Object);
            int anyIdMoreZero = 2;
            //Act
            announcementService.GetAnnouncementById(anyIdMoreZero);
            //Assert
            iRepository.Verify(inv => inv.GetById(anyIdMoreZero), Times.Once);
        }
    }
}
