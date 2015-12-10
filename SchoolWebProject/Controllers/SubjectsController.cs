using System;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolWebProject.Controllers
{
    public class SubjectsController : BaseApiController
    {
        private ISubjectService subjectService;
        private IScheduleService scheduleServise;

        public SubjectsController(ILogger logger, ISubjectService subjects, IScheduleService schedule)
            : base(logger)
        {
            this.subjectService = subjects;
            this.scheduleServise = schedule;
        }

        // GET api/subject
        public IEnumerable<ViewSubject> Get()
        {
            var subjects = this.subjectService.GetAllSubjects();
            List<ViewSubject> viewModel = new List<ViewSubject>();
            foreach (var v in subjects)
                viewModel.Add(ViewSubject.CreateSimpleSubject(v));
            return viewModel;
        }

        // GET api/subjects/5
        public ViewSubject Get(int id)
        {
            var subject = this.subjectService.GetSubjectById(id);
            var viewModel = ViewSubject.CreateSimpleSubject(subject);
            return viewModel;
        }

           [Route("api/subject/getSubjectForGroup/{GroupId}")]
        public IEnumerable<ViewSubject> GetSubjectForGroup(int GroupId)
        {
            var subjects = this.scheduleServise.GetSubjectForGroupByGroupId(GroupId);
            List<ViewSubject> viewModel = new List<ViewSubject>();
            foreach (var subject in subjects)
            {
                viewModel.Add(new ViewSubject { Id = subject.Id, Name = subject.Name });
            }
            return viewModel;
        }

        // POST api/subjects
        public void Post([FromBody]ViewSubject value)
        {
            Subject subject = AutoMapper.Mapper.Map<ViewSubject, Subject>(value);
            this.subjectService.AddSubject(subject);
        }

        // PUT api/subjects/5
        public void Put(int id, [FromBody]ViewSubject value)
        {
            var subject = this.subjectService.GetSubjectById(value.Id);
            AutoMapper.Mapper.Map<ViewSubject, Subject>(value, subject);
            this.subjectService.UpdateSubject(subject);
        }

        // DELETE api/subjects/5
        public void Delete(int id)
        {
            this.subjectService.RemoveSubject(id);
        }
    }
}
