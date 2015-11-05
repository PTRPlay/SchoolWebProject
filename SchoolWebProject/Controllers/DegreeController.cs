using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Controllers
{
    public class DegreeController : ApiController
    {
        // GET api/degree
        public IEnumerable<string> Get()
        {
            var degrees = new SchoolContext().TeacherDegrees;
            var degreeNames = from entry in degrees select entry.Name;
            return degreeNames;
        }

        // GET api/degree/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/degree
        public void Post([FromBody]string value)
        {
        }

        // PUT api/degree/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/degree/5
        public void Delete(int id)
        {
        }
    }
}
