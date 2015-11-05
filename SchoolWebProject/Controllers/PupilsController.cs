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
        // GET api/pupils
        public IEnumerable<ViewPupil> Get()
        {
            var pupils = new PupilService(new SerilogLogger(),
                            new GenericRepository<Pupil>(new DbFactory()),
                            new UnitOfWork(new DbFactory()))
                           .GetAllPupils();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<ViewPupil>>(pupils);
            return viewModel;
        }

        // GET api/pupils/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/pupils
        public void Post([FromBody]string value)
        {
        }

        // PUT api/pupils/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/pupils/5
        public void Delete(int id)
        {
        }
    }
}
