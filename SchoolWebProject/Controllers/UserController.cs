using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services.Interfaces;

namespace SchoolWebProject.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        public readonly ILogger Logger = null;
        private IUserService userService;

        public UserController(ILogger tmplogger, IUserService accService)
        {
            this.Logger = tmplogger;
            this.userService = accService;
        }

        // GET: api/User/5
        public User Get(int id)
        {
            return this.userService.GetById(id);
        }
    }
}
