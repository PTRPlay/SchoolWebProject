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

namespace SchoolWebProject.Controllers
{
    public class HolidaysController : BaseApiController
    {

        private IHolidaysService holidaysService;

        public HolidaysController(ILogger logger, IHolidaysService holidaysService) : base(logger) 
        {
            this.holidaysService = holidaysService;
        }
        
        // GET api/holidays
        public IEnumerable<Holidays> Get()
        {
            return holidaysService.GetAllHolidays();
        }

        // GET api/holidays/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/holidays
        public void Post([FromBody]string value)
        {
        }

        // PUT api/holidays/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/holidays/5
        public void Delete(int id)
        {
        }
    }
}
