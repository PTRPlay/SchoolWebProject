using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Controllers
{
    public class TeachersCategoryController : ApiController
    {
        // GET api/teacherscategory
        public IEnumerable<string> Get()
        {
            var categories = new SchoolContext().TeacherCategories;
            var nameCategories = from entry in categories select entry.Name;
            return nameCategories;
        }

        // GET api/teacherscategory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/teacherscategory
        public void Post([FromBody]string result)
        {
            var bin = result;
        }

        // PUT api/teacherscategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teacherscategory/5
        public void Delete(int id)
        {
        }
    }
}
