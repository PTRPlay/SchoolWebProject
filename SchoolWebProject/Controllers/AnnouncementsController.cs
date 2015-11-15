using System;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolWebProject.Controllers
{
        public class AnnouncementsController : ApiController
    {
        private ILogger getLogger;

        private IAnnouncementService announcementService;

        public AnnouncementsController(ILogger logger, IAnnouncementService announcementService) 
        {
            this.getLogger = logger;
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
        public void Post([FromBody]ViewAnnouncement value)
        {
            var bin = new SchoolContext();
            Announcement announcement = AutoMapper.Mapper.Map<ViewAnnouncement, Announcement>(value);
            bin.Announcements.Add(announcement);
            bin.SaveChanges();
 
        }

        // PUT api/announcements/5
        public void Put(int id, [FromBody]ViewAnnouncement value)
        {
            var announcement = announcementService.GetAnnouncementById(value.Id);
            AutoMapper.Mapper.Map<ViewAnnouncement, Announcement>(value, announcement);
            announcementService.UpdateAnnouncement(announcement);
        }

        // DELETE api/announcements/5
        public void Delete(int id)
        {
        }
    }
}
