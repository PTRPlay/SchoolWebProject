using System;
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
            Pupil pupil = AutoMapper.Mapper.Map<ViewPupil, Pupil>(value);
            this.pupilService.AddPupil(pupil);
            this.pupilService.SavePupil();
        }

        // PUT api/pupils/5
         [HttpPost]
        public void Put(int id, [FromBody]ViewPupil value)
        {
            var pupil = pupilService.GetProfileById(value.Id);
            AutoMapper.Mapper.Map<ViewPupil, Pupil>(value, (Pupil)pupil);
            pupilService.UpdateProfile(pupil);
            pupilService.SavePupil();
        }

        // DELETE api/pupils/5
        [HttpDelete]
        public void Delete(int id)
        {
            pupilService.RemovePupil(id);
            this.pupilService.SavePupil();
        }
    }
}
