using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
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
    }
}
