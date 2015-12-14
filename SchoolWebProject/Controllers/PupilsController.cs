using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using sm = SchoolWebProject.Services.Models;


namespace SchoolWebProject.Controllers
{
    public class PupilsController : BaseApiController
    {
        private IPupilService pupilService;
        private IAccountService accountService;

        public PupilsController(ILogger logger, IPupilService pupilService, IAccountService accService) : base(logger) 
        {
            this.pupilService = pupilService;
            this.accountService = accService;
        }

        // GET api/pupils
        public IEnumerable<sm.ViewPupil> Get()
        {
            var pupils = this.pupilService.GetAllPupils();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<sm.ViewPupil>>(pupils);
            logger.Info("Retrieving all pupils");
            return viewModel;
        }

        // GET api/pupils/2/25/LastName ASC/Пилипів
        public object GetPage(int page, int amount, string sorting, string filtering = null)
        {
            int pageCount;
            var pupils = this.pupilService.GetPage(page, amount, sorting, filtering, out pageCount);
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<sm.ViewPupil>>(pupils);
            var pupilPage = new  { Pupils = viewModel, PageCount = pageCount };
            logger.Info("Retrieving page with pupils from a server. Page # {0}, amount - {1}", page, amount);
            return pupilPage;
        }

        // GET api/pupils/5
        public sm.ViewPupil Get(int id)
        {
            var pupil = this.pupilService.GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<Pupil, sm.ViewPupil>(pupil);
            logger.Info("Retrieving pupil with id {0}", id);
            return viewModel;
        }

        // POST api/pupils
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]sm.ViewPupil value)
        {
            Pupil pupil = AutoMapper.Mapper.Map<sm.ViewPupil, Pupil>(value);
            pupil.RoleId = 3;
            if (pupil.Email != null)
            {
                pupil.LogInData = this.accountService.GenerateUserLoginData(pupil);
            }

            this.pupilService.AddPupil(pupil);
            logger.Info("Added pupil {0} {1}", value.FirstName, value.LastName);
        }

        // PUT api/pupils/5
         [HttpPost]
         [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]sm.ViewPupil value)
        {
            var pupil = this.pupilService.GetProfileById(value.Id);
            AutoMapper.Mapper.Map<sm.ViewPupil, Pupil>(value, (Pupil)pupil);
            this.pupilService.UpdateProfile(pupil);
            logger.Info("Edited pupil {0} {1}", value.FirstName, value.LastName);
        }

        // DELETE api/pupils/5
        [HttpDelete]
        [Authorize(Roles = "Admin, Teacher")]
        public void Delete(int id)
        {
            this.pupilService.RemovePupil(id);
            logger.Info("Deleted pupil with id {0}", id);
        }
    }
}
