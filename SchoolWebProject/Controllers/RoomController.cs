﻿using SchoolWebProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolWebProject.Controllers
{
    public class RoomController : ApiController
    {
        private IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }
        // GET: api/Room
        public IEnumerable<string> Get()
        {
            return roomService.GetAllRoom();
        }

        // GET: api/Room/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Room
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
