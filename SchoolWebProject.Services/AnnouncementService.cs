using System;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public class AnnouncementService : BaseService, IAnnouncementService
    {
        private IUnitOfWork unitOfWork;

        public AnnouncementService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Announcement> GetAllAnnouncements()
        {
            logger.Info("Get all announcements.");
            return this.unitOfWork.AnnouncementRepository.GetAll();
        }

        public Announcement GetAnnouncementById(int id)
        {
            logger.Info("Get announcment by id. Id = {0}", id);
            return this.unitOfWork.AnnouncementRepository.GetById(id);
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            logger.Info("Update announcement {0}", announcement.Title);
            this.unitOfWork.AnnouncementRepository.Update(announcement);
        }

        public void AddAnnouncement(Announcement announcement)
        {
            logger.Info("Add announcement {0}", announcement.Title);
            this.unitOfWork.AnnouncementRepository.Add(announcement);
            this.unitOfWork.SaveChanges();
        }

        public void RemoveAnnouncement(Announcement announcement)
        {
            logger.Info("Remove annoncement {0}", announcement.Title);
            this.unitOfWork.AnnouncementRepository.Delete(announcement);
        }
    }
}
