using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;


namespace SchoolWebProject.Controllers
{
        public class AnnouncementsController : BaseApiController
    {
        private IAnnouncementService announcementService;

        public AnnouncementsController(ILogger logger, IAnnouncementService announcementService) : base(logger) 
        {
            this.announcementService = announcementService;
        }

        // GET api/announcements
        public IEnumerable<ViewAnnouncement> Get()
        {
            logger.Info("Get all announcements");
            return this.announcementService.GetAllAnnouncements();
        }

        // GET api/announcements/5
        public ViewAnnouncement Get(int id)
        {
            var announcement = this.announcementService.GetAnnouncementById(id);
            return announcement;
        }

        // POST api/announcements
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]ViewAnnouncement announcement)
        {
			this.announcementService.AddAnnouncement(announcement);
        }

        // PUT api/announcements/5
        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]ViewAnnouncement announcement)
        {
            this.announcementService.UpdateAnnouncement(id, announcement);
        }

        // DELETE api/announcements/5
        [Authorize(Roles = "Admin, Teacher")]
        public void Delete(int id)
        {
            this.announcementService.RemoveAnnouncement(id);
 		}
    }
}
