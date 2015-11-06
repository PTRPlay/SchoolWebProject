﻿using System;
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

        private AnnouncementService announcementService;

        public AnnouncementsController(ILogger logger, AnnouncementService announcementService) 
        {
            this.getLogger = logger;
            this.announcementService = announcementService;
        }

        // GET api/announcements
        public IEnumerable<ViewAnnouncement> Get()
        {
            var announcement = this.announcementService.GetAllAnnouncements();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Announcement>, IEnumerable<ViewAnnouncement>>(announcement);
            return viewModel;
        }

        // GET api/announcements/5
        public ViewAnnouncement Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/announcements
        public void Post([FromBody]ViewAnnouncement value)
        {
        }

        // PUT api/announcements/5
        public void Put(int id, [FromBody]ViewAnnouncement value)
        {
        }

        // DELETE api/announcements/5
        public void Delete(int id)
        {
        }
    }
}
