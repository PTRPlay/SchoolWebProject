using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;

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
        public IEnumerable<ViewPupil> Get()
        {
            var pupils = this.pupilService.GetAllPupils();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<ViewPupil>>(pupils);
            return viewModel;
        }

        // GET api/pupils/2/25/asc
        public PupilPageData GetPage(int page, int amount, string sorting, string filtering = null)
        {
            int pageCount;
            var pupils = this.pupilService.GetPage(page, amount, sorting, filtering, out pageCount);
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<ViewPupil>>(pupils);
            PupilPageData pupilPage = new PupilPageData() { Pupils = viewModel, PageCount = pageCount };
            logger.Info("Retrieving page with pupils from a server");
            return pupilPage;
        }

        // GET api/pupils/5
        public ViewPupil Get(int id)
        {
            var pupil = this.pupilService.GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<Pupil, ViewPupil>(pupil);
            return viewModel;
        }

        // POST api/pupils
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]ViewPupil value)
        {
            Pupil pupil = AutoMapper.Mapper.Map<ViewPupil, Pupil>(value);
            pupil.RoleId = 3;
            if (pupil.Email != null)
            {
                pupil.LogInData = this.accountService.GenerateUserLoginData(pupil);
            }

            this.pupilService.AddPupil(pupil);
        }

        // PUT api/pupils/5
         [HttpPost]
         [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]ViewPupil value)
        {
            var pupil = this.pupilService.GetProfileById(value.Id);
            AutoMapper.Mapper.Map<ViewPupil, Pupil>(value, (Pupil)pupil);
            this.pupilService.UpdateProfile(pupil);
        }

        // DELETE api/pupils/5
        [HttpDelete]
        [Authorize(Roles = "Admin, Teacher")]
        public void Delete(int id)
        {
            this.pupilService.RemovePupil(id);
        }
    }
}
