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

        public SubjectsController(ILogger logger, ISubjectService subjects)
            : base(logger)
        {
            this.subjectService = subjects;
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
