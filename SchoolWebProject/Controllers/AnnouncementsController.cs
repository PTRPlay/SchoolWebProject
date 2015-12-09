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
            var announcements = this.announcementService.GetAllAnnouncements();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Announcement>, IEnumerable<ViewAnnouncement>>(announcements);
            return viewModel;
        }

        // GET api/announcements/5
        public ViewAnnouncement Get(int id)
        {
            var announcement = this.announcementService.GetAnnouncementById(id);
            var viewModel = AutoMapper.Mapper.Map<Announcement, ViewAnnouncement>(announcement);
            return viewModel;
        }

        // POST api/announcements
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]ViewAnnouncement value)
        {
            Announcement announcement = AutoMapper.Mapper.Map<ViewAnnouncement, Announcement>(value);
            this.announcementService.AddAnnouncement(announcement);
        }

        // PUT api/announcements/5
        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]ViewAnnouncement value)
        {
            var announcement = this.announcementService.GetAnnouncementById(value.Id);
            AutoMapper.Mapper.Map<ViewAnnouncement, Announcement>(value, announcement);
            this.announcementService.UpdateAnnouncement(announcement);
        }

        // DELETE api/announcements/5
        [Authorize(Roles = "Admin, Teacher")]
        public void Delete(int id)
        {
        }
    }
}
