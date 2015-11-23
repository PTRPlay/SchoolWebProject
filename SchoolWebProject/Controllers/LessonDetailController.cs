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

namespace SchoolWebProject.Controllers
{
    public class LessonDetailController : BaseApiController
    {
        private LessonDetailService lessonDetailService;

        public LessonDetailController(ILogger logger, LessonDetailService service) : base(logger)
        {
            this.lessonDetailService = service;
        }

        // GET api/lessonDetail
        public IEnumerable<ViewLessonDetail> Get()
        {
            var lessonDetail = this.lessonDetailService.GetAllLessonDetails();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<LessonDetail>, IEnumerable<ViewLessonDetail>>(lessonDetail);
            return viewModel;
        }

        // GET api/lessonDetail/5
        public ViewLessonDetail Get(int id)
        {
            var viewModel = AutoMapper.Mapper.Map<LessonDetail, ViewLessonDetail>(this.lessonDetailService.GetLessonDetailById(id));
            return viewModel;
        }

        // PUT api/lessonDetail/5
        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]ViewLessonDetail value)
        {
            var lessonDetail = this.lessonDetailService.GetLessonDetailById(id);
            AutoMapper.Mapper.Map<ViewLessonDetail, LessonDetail>(value, lessonDetail);
            this.lessonDetailService.UpdateLessonDetail(lessonDetail);
            this.lessonDetailService.SaveLessonDetail();
        }

        // POST api/lessonDetail
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]ViewLessonDetail value)
        {
            var lessonDetail = AutoMapper.Mapper.Map<ViewLessonDetail, LessonDetail>(value);
            this.lessonDetailService.AddLessonDetail(lessonDetail);
        }

        // DELETE api/lessonDetail/5
        [Authorize(Roles = "Admin, Teacher")]
        public void Delete(int id)
        {
        }
    }
}
