﻿using System;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Models;

namespace SchoolWebProject.Controllers
{
    public class PupilsController : ApiController
    {
        private ILogger getLogger;

        private PupilService pupilService;

        public PupilsController(ILogger logger, PupilService pupilService) 
        {
            this.getLogger = logger;
            this.pupilService = pupilService;
        }

        // GET api/pupils
        public IEnumerable<ViewPupil> Get()
        {
            var pupils = pupilService.GetAllPupils();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<ViewPupil>>(pupils);
            return viewModel;
        }

        // GET api/pupils/5
        public ViewPupil Get(int id)
        {
            var pupil = pupilService.GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<Pupil, ViewPupil>(pupil);
            return viewModel;
        }

        // POST api/pupils
        public void Post([FromBody]ViewPupil value)
        {
        }

        // PUT api/pupils/5
        public void Put(int id, [FromBody]ViewPupil value)
        {
        }

        // DELETE api/pupils/5
        public void Delete(int id)
        {
        }
    }
}
