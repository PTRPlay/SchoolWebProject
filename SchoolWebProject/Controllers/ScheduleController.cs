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
        private ILogger logger;
        private IScheduleService scheduleService;

        public ScheduleController(ILogger logger,ScheduleService scheduleService) 
        {
            this.logger = logger;
            this.scheduleService = scheduleService;
        }

        public IEnumerable<ViewSchedule> Get()
        {
            var schedules = scheduleService.GetAllSchedules();
            var viewSchedules = AutoMapper.Mapper.Map<IEnumerable<Schedule> , IEnumerable<ViewSchedule>>(schedules);
            logger.Info("Get All Schedule");
            return viewSchedules;
        }

        public IEnumerable<ViewSchedule> Get(int teacher,int group)
        {
            var schedules = this.scheduleService.GetByFilter(teacher , group);
            var viewSchedules = AutoMapper.Mapper.Map<IEnumerable<Schedule>, IEnumerable<ViewSchedule>>(schedules);
            logger.Info("Get part Schedule");
            return viewSchedules;
        }
        
        // POST api/schedule
        [Authorize(Roles = "Admin, Teacher")]
        public void Post(IEnumerable<ViewSchedule> modificationsViewSchedules)
        {
            var schedules = AutoMapper.Mapper.Map<IEnumerable<ViewSchedule>, IEnumerable<Schedule>>(modificationsViewSchedules);
            this.scheduleService.ModifySchedule(schedules);
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
