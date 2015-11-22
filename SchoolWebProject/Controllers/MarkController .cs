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
    public class MarkController : BaseApiController
    {
        private MarkService markService;

        public MarkController(ILogger logger, MarkService markService) : base(logger) 
        {
            this.markService = markService;
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
        public void Post([FromBody]ViewMark vm)
        {
            Mark mark = markService.GetMarkById(vm.Id);
            mark.Value = vm.Value;
            markService.UpdateMark(mark);
            markService.SaveMark();
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
