using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services.Models;

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

        public IEnumerable<ViewAnnouncement> GetAllAnnouncements()
        {
            var announcements = this.unitOfWork.AnnouncementRepository.GetAll().OrderByDescending(a => a.DataPublished);
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Announcement>, IEnumerable<ViewAnnouncement>>(announcements);
            logger.Info("Get all announcements.");
            return viewModel;
        }

        public ViewAnnouncement GetAnnouncementById(int id)
        {
            var announcement = this.unitOfWork.AnnouncementRepository.GetById(id);
            var viewModel = AutoMapper.Mapper.Map<Announcement, ViewAnnouncement>(announcement);
            logger.Info("Get announcment by id. Id = {0}", id);
            return viewModel;
        }

        public void UpdateAnnouncement(int id, ViewAnnouncement value)
        {
            var announcement = this.unitOfWork.AnnouncementRepository.GetById(id);
            AutoMapper.Mapper.Map<ViewAnnouncement, Announcement>(value, announcement);
            this.unitOfWork.AnnouncementRepository.Update(announcement);
            logger.Info("Update announcement {0}", announcement.Title);
            this.unitOfWork.SaveChanges();
        }

        public void AddAnnouncement(ViewAnnouncement value)
        {
            var announcement = AutoMapper.Mapper.Map<ViewAnnouncement, Announcement>(value);
            this.unitOfWork.AnnouncementRepository.Add(announcement);
            logger.Info("Add announcement {0}", announcement.Title);
            this.unitOfWork.SaveChanges();
        }

        public void RemoveAnnouncement(int id)
        {
            var announcement = this.unitOfWork.AnnouncementRepository.GetById(id);
            this.unitOfWork.AnnouncementRepository.Delete(announcement);
            this.unitOfWork.SaveChanges();
            logger.Info("Remove annoncement {0}", announcement.Title);
        }
    }
}
