using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
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
            repository = announcementRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Announcement> GetAllAnnouncements()
        {
            return repository.GetAll();
        }

        public Announcement GetAnnouncementById(int id)
        {
            return repository.GetById(id);
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            repository.Update(announcement);
        }

        public void AddAnnouncement(Announcement announcement)
        {
            repository.Add(announcement);
        }

        public void RemoveAnnouncement(Announcement announcement)
        {
            repository.Delete(announcement);
        }

        public void SaveAnnouncement()
        {
            unitOfWork.SaveChanges();
        }
    }
}
