using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
<<<<<<< HEAD
using SchoolWebProject.Services;
=======
using System.Web.Mvc;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
>>>>>>> e17e600b6b6176217a925e7c960a5d4dcca1cf81
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Interfaces;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Controllers
{
    public class GroupsController : BaseApiController
    {
        private IGroupService groupService;

        public GroupsController(ILogger logger, IGroupService groupService) : base(logger) 
        {
            this.groupService = groupService;
        }

        // GET api/groups
        public IEnumerable<ViewGroup> Get()
        {
            var groups = groupService.GetAllGroups();
            List<ViewGroup> viewModel = new List<ViewGroup>();
            foreach (var v in groups)
                viewModel.Add(ViewGroup.CreateSimpleGroup(v));
            return viewModel;
        }
<<<<<<< HEAD
        // GET api/groups/8
        public ViewGroup Get(int id)
        {
            var group = this.groupService.GetGroupById(id);
            var viewModel = ViewGroup.CreateSimpleGroup(group);
            return viewModel;
        }

        // POST api/groups
        public void Post([FromBody]ViewGroup value)
        {
            Group group = AutoMapper.Mapper.Map<ViewGroup, Group>(value);
            this.groupService.AddGroup(group);
        }

        // PUT api/groups/5
        [HttpPost]
        public void Put(int id, [FromBody]ViewGroup value)
        {
            var group = groupService.GetGroupById(value.Id);
            AutoMapper.Mapper.Map<ViewGroup, Group>(value, group);
            groupService.UpdateGroup(group);
        }

        // DELETE api/groups/5
        [HttpDelete]
        public void Delete(int id)
        {
            groupService.RemoveGroup(id);
        }
=======
>>>>>>> e17e600b6b6176217a925e7c960a5d4dcca1cf81
    }
}
