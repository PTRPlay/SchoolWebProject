using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;

namespace SchoolWebProject.Controllers
{
    public class TeachersController : ApiController
    {
        // GET api/teachers
        public string Get()
        {
            var temp = new TeacherService(new Logger(), new GenericRepository<Teacher>(new DbFactory()));
            List<Teacher> listOfTeachers = new List<Teacher>();
            Teacher teacher = new Teacher();
            foreach (var user in temp.GetAllTeachers())
            {
                teacher = new Teacher();
                teacher.FirstName = user.FirstName;
                teacher.LastName = user.LastName;
                listOfTeachers.Add(teacher);
            }
            IEnumerable<Teacher> teachers = listOfTeachers;
            var jsonSerializer = new JavaScriptSerializer();
            var json = jsonSerializer.Serialize(teachers);
            return json;
        }

        // GET api/teachers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/teachers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/teachers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teachers/5
        public void Delete(int id)
        {
        }
    }
}
