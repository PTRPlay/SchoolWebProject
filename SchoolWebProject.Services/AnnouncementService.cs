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

        private ILogger announcementLogger;

        private IUnitOfWork unitOfWork;

        public AnnouncementService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.announcementLogger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Announcement> GetAllAnnouncements()
        {
            return this.unitOfWork.AnnouncementRepository.GetAll();
        }

        public Announcement GetAnnouncementById(int id)
        {
            return this.unitOfWork.AnnouncementRepository.GetById(id);
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            this.unitOfWork.AnnouncementRepository.Update(announcement);
        }

        public void AddAnnouncement(Announcement announcement)
        {
            this.unitOfWork.AnnouncementRepository.Add(announcement);
            this.unitOfWork.SaveChanges();
        }

        public void RemoveAnnouncement(Announcement announcement)
        {
            this.unitOfWork.AnnouncementRepository.Delete(announcement);
        }
    }
}
