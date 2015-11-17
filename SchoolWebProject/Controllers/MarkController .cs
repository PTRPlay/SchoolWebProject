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
    public class MarkController : ApiController
    {
        
        private ILogger getLogger;

        private MarkService markService;

        public MarkController(ILogger logger) 
        {
            this.getLogger = logger;
            this.markService = new MarkService(this.getLogger);
        }

        // GET api/mark
        public IEnumerable<ViewMark> Get()
        {
            var marks = markService.GetAllMarks();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Mark>, IEnumerable<ViewMark>>(marks);
            return viewModel;
        }

        // GET api/mark/subjectId/groupId
        public IEnumerable<ViewMark> GetBySubjectAndGroup(int subjectId, int groupId)
        {
            var marks = markService.GetMarksBySubjectAndGroup(subjectId, groupId);
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Mark>, IEnumerable<ViewMark>>(marks);
            return viewModel;
        }

        // GET api/mark/5
        public ViewMark Get(int id)
        {
            var viewModel = AutoMapper.Mapper.Map<Mark, ViewMark>(markService.GetMarkById(id));
            return viewModel;
        }

        // POST api/mark
        public void Post([FromBody]ViewMark value)
        {
            var mark = AutoMapper.Mapper.Map<ViewMark, Mark>(value);
            new MarkService(this.getLogger).AddMark(mark);
            this.Get();
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
