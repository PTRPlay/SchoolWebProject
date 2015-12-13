using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;


namespace SchoolWebProject.Controllers
{
    public class LessonDetailController : BaseApiController
    {
        private LessonDetailService lessonDetailService;
        private ScheduleService scheduleServise;

        public LessonDetailController(ILogger logger, LessonDetailService service, ScheduleService schedule) : base(logger)
        {
            this.lessonDetailService = service;
            this.scheduleServise = schedule;
        }

        // GET api/lessonDetail
        public IEnumerable<ViewLessonDetail> Get()
        {
            return this.lessonDetailService.GetAllLessonDetails();
        }

        // GET api/lessonDetail/5
        public ViewLessonDetail Get(int id)
        {
            return this.lessonDetailService.GetLessonDetailById(id); ;
        }

        // PUT api/lessonDetail/5
        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]LessonDetail value)
        {
            this.lessonDetailService.UpdateLessonDetail(value);
        }

        // POST api/lessonDetail
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]ViewLessonDetail value)
        {
            var schedule = this.scheduleServise.GetScheduleById(value.Id);
            this.lessonDetailService.GenereteLessonDeatail(schedule);
        }
    }
}
