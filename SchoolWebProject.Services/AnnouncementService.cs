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
        private IRepository<Announcement> repository;

        private IUnitOfWork unitOfWork;

        public AnnouncementService(ILogger logger, IRepository<Announcement> announcementRepository, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.repository = announcementRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Announcement> GetAllAnnouncements()
        {
            return this.repository.GetAll();
        }

        public Announcement GetAnnouncementById(int id)
        {
            return this.repository.GetById(id);
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            this.repository.Update(announcement);
        }

        public void AddAnnouncement(Announcement announcement)
        {
            this.repository.Add(announcement);
        }

        public void RemoveAnnouncement(Announcement announcement)
        {
            this.repository.Delete(announcement);
        }

        public void SaveAnnouncement()
        {
            unitOfWork.SaveChanges();
        }
    }
}
