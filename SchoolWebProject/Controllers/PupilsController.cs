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
using sModels = SchoolWebProject.Services.Models;


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
        public IEnumerable<sModels.ViewPupil> Get()
        {
            return this.pupilService.GetAllPupils();
        }

        // GET api/pupils/2/25/LastName ASC/Пилипів
        public object GetPage(int page, int amount, string sorting, string filtering = null)
        {
            int pageCount;
            var pupils = this.pupilService.GetPage(page, amount, sorting, filtering, out pageCount);
            var pupilPage = new  { Pupils = pupils, PageCount = pageCount };
            return pupilPage;
        }

        // GET api/pupils/5
        public sModels.ViewPupil Get(int id)
        {
            var pupil = this.pupilService.GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<Pupil, sModels.ViewPupil>(pupil);
            return viewModel;
        }

        // POST api/pupils
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]sModels.ViewPupil value)
        {
            this.pupilService.AddPupil(value);
        }

        // PUT api/pupils/5
         [HttpPost]
         [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]sModels.ViewPupil value)
        {
            this.pupilService.UpdateProfile(value);
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
