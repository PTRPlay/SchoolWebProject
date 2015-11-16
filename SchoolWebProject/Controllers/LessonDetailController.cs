using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Models;
using AutoMapper;

namespace SchoolWebProject.Controllers
{
    public class LessonDetailController : ApiController
    {

        private ILogger getLogger;
        private LessonDetailService lessonDetailService;
        private IRepository<LessonDetail> iRepo;


        public LessonDetailController(ILogger logger, LessonDetailService service)
        {
            this.getLogger = logger;
            this.lessonDetailService = service;
        }

        // GET api/lessonDetail
        public IEnumerable<ViewLessonDetail> Get()
        {
            var lessonDetail = lessonDetailService.GetAllLessonDetails();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<LessonDetail>, IEnumerable<ViewLessonDetail>>(lessonDetail);
            return viewModel;
        }

        // GET api/mark/5
        public ViewLessonDetail Get(int id)
        {
            var viewModel = AutoMapper.Mapper.Map<LessonDetail, ViewLessonDetail>(lessonDetailService.GetLessonDetailById(id));
            return viewModel;
        }

        // POST api/mark
        public void Post([FromBody]ViewLessonDetail value)
        {
            var lessonDetail = AutoMapper.Mapper.Map<ViewLessonDetail, LessonDetail>(value);
            lessonDetailService.AddLessonDetail(lessonDetail);
        }

        // PUT api/mark/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teacher/5
        public void Delete(int id)
        {
        }
    }
}
