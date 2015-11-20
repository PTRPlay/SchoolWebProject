using SchoolWebProject.Domain.Models;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolWebProject.Controllers
{
    public class ScheduleController : ApiController
    {
        // GET api/schedule
        public IEnumerable<ViewSchedule> Get()
        {
            var scheldules = new SchoolContext().Schedules;
            var viewSchedules = AutoMapper.Mapper.Map<IEnumerable<Schedule>,IEnumerable<ViewSchedule>>(scheldules);
            return viewSchedules;
        }

        // GET api/schedule/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/schedule
        public void Post([FromBody]string value)
        {
        }

        // PUT api/schedule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/schedule/5
        public void Delete(int id)
        {
        }
    }
}
