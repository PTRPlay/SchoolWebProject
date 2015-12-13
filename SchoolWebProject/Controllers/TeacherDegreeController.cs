using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;


namespace SchoolWebProject.Controllers
{
    public class TeacherDegreeController : BaseApiController
    {
        private TeacherDegreeService teacherDegreeService;

        public TeacherDegreeController(ILogger logger, TeacherDegreeService teacherDegreeService)
            : base(logger)
        {
            this.teacherDegreeService = teacherDegreeService;
        }

        // GET api/teacherDegree
        public IEnumerable<ViewTeacherDegree> Get()
        {
            logger.Info("Gets Teacher Degree");
            return this.teacherDegreeService.GetAllTeacherDegrees();
        }

        // GET api/teacherDegree/5
        public ViewTeacherDegree Get(int id)
        {
            var teacherDegree = this.teacherDegreeService.GetTeacherDegreeById(id);
            logger.Info("Getted teacher category {0}", teacherDegree.Name);
            return teacherDegree;
        }

        // POST api/teacherDegree
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]ViewTeacherDegree value)
        {
            this.teacherDegreeService.AddTeacherDegree(value);
            logger.Info("Added new teacher degree");
        }

        // PUT api/teacherDegree/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]ViewTeacherDegree value)
        {
            this.teacherDegreeService.UpdateTeacherDegree(id, value);
            logger.Info("Edited teacher degree");
        }

        // DELETE api/teacherDegree/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            this.teacherDegreeService.DeleteTeacherDegree(id);
            logger.Info("Delete teacher degree");
        }
    }
}
