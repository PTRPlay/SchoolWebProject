using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public interface IAnnouncementService
    {
        IEnumerable<ViewAnnouncement> GetAllAnnouncements();

        ViewAnnouncement GetAnnouncementById(int id);

        void UpdateAnnouncement(int id, ViewAnnouncement announcement);

        void AddAnnouncement(ViewAnnouncement announcement);

        void RemoveAnnouncement(int id);
    }
}
