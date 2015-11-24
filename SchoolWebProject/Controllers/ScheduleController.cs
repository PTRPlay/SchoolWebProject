using SchoolWebProject.Domain.Models;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Infrastructure;
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
        public IEnumerable<ViewSchedule> Get()
        {
            var scheldules = new SchoolContext().Schedules;
            var viewSchedules = AutoMapper.Mapper.Map<IEnumerable<Schedule>,IEnumerable<ViewSchedule>>(scheldules);
            return viewSchedules;
        }

        public IEnumerable<ViewSchedule> Get(string filter)
        {
            //TO DO 
            // IT IS NOT FINISHED YET

            //string[] filters = filter.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            var scheldules = new SchoolContext().Schedules.
                Where((enty) => enty.Teacher.FirstName + enty.Teacher.MiddleName + enty.Teacher.LastName == filter).ToArray();
                //Intersect(new SchoolContext().Schedules.
                //Where(enty=>enty.Group.NameNumber+enty.Group.NameLetter == filters[1]));
            var viewSchedules = AutoMapper.Mapper.Map<IEnumerable<Schedule>, IEnumerable<ViewSchedule>>(scheldules);
            return viewSchedules;
        }

        // POST api/schedule
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/schedule/5
        [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/schedule/5
        [Authorize(Roles = "Admin, Teacher")]
        public void Delete(int id)
        {
        }
    }
}
