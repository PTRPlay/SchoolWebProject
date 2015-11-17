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

        private IPupilService pupilService;

        public PupilsController(ILogger logger, IPupilService pupilService) 
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

        // GET api/pupils/2/25/asc
        public IEnumerable<ViewPupil> GetPage(int page, int amount, string sorting)
        {
            var pupils = pupilService.GetPage(page, amount, sorting);
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
            System.Diagnostics.Debug.WriteLine("From post");
            System.Diagnostics.Debug.WriteLine("Saving data " +value.LastName);
            var bin = new SchoolContext();
            Pupil pupil = AutoMapper.Mapper.Map<ViewPupil, Pupil>(value);
            //bin.Entry(pupil).State = System.Data.Entity.EntityState.Added;
            bin.Users.Add(pupil);
            bin.SaveChanges();
            
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
