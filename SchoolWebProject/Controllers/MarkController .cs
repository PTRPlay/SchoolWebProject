﻿using System;
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
            var marks = this.markService.GetAllMarks();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Mark>, IEnumerable<ViewMark>>(marks);
            return viewModel;
        }

        // GET api/mark/subjectId/groupId
        public IEnumerable<ViewMark> GetBySubjectAndGroup(int subjectId, int groupId)
        {
            var marks = this.markService.GetMarksBySubjectAndGroup(subjectId, groupId);
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Mark>, IEnumerable<ViewMark>>(marks);
            return viewModel;
        }

        // GET api/mark/5
        public ViewMark Get(int id)
        {
            var viewModel = AutoMapper.Mapper.Map<Mark, ViewMark>(this.markService.GetMarkById(id));
            return viewModel;
        }

        // POST api/mark
        [Authorize(Roles = "Admin, Teacher")]
        public void Post([FromBody]ViewMark vm)
        {
            Mark mark = this.markService.GetMarkById(vm.Id);
            if (mark == null)
            {
                var newMark = AutoMapper.Mapper.Map<ViewMark, Mark>(vm);
                this.markService.AddMark(newMark);
            }
            else
            {
                mark.Value = vm.Value;
                this.markService.UpdateMark(mark);
            }
        }

        // PUT api/mark/5
        [Authorize(Roles = "Admin, Teacher")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teacher/5
        [Authorize(Roles = "Admin, Teacher")]
        public void Delete(int id)
        {
        }
    }
}
