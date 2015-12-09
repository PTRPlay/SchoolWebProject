using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface IAnnouncementService
    {
        IEnumerable<Announcement> GetAllAnnouncements();

        Announcement GetAnnouncementById(int id);

        void UpdateAnnouncement(Announcement announcement);

        void AddAnnouncement(Announcement announcement);

        void RemoveAnnouncement(Announcement announcement);
    }
}
