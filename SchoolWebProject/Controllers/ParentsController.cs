﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services.Interfaces;
using SchoolWebProject.Services;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Models;

namespace SchoolWebProject.Controllers
{
    public class ParentsController : BaseApiController
    {
        private IParentService parentService;
        private IAccountService accountService;

        public ParentsController(ILogger logger, IParentService parentService, IAccountService accountService) : base(logger)
        {
            this.parentService = parentService;
            this.accountService = accountService;
        }
        // GET api/parrents
        public IEnumerable<ViewParent> Get()
        {
            var parents = this.parentService.GetAllParents();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Parent>, IEnumerable<ViewParent>>(parents);
            logger.Info("Get all parents");
            return viewModel;
        }

        // GET api/parrents/5
        public ViewParent Get(int id)
        {
            var parent = this.parentService.GetParent(id);
            var viewModel = AutoMapper.Mapper.Map<Parent, ViewParent>(parent);
            logger.Info("Get parent by id {0}: First name: {1}, Last name: {2}", id, viewModel.FirstName, viewModel.LastName);
            return viewModel;
        }

        // POST api/parrents
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]ViewParent value)
        {
            var parent = AutoMapper.Mapper.Map<ViewParent, Parent>(value);
            parent.RoleId = 4;
            if (parent.Email != null)
            {
                parent.LogInData = this.accountService.GenerateUserLoginData(parent);
            }
            this.parentService.AddParent(parent);
            logger.Info("Added parent {0} {1}", parent.FirstName, parent.LastName);
        }

        // PUT api/parrents/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]ViewParent value)
        {
            var parent = this.parentService.GetParent(value.Id);
            AutoMapper.Mapper.Map<ViewParent, Parent>(value, (Parent)parent);
            this.parentService.UpdateParent(parent);
            logger.Info("Parent edited: {0} {1}", parent.FirstName, parent.LastName);
        }

        // DELETE api/parrents/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            this.parentService.RemoveParent(id);
            logger.Info("Parent removed: ID {0}", id);
        }
    }
}
