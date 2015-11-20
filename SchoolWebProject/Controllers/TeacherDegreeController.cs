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
            var teacherCategories = teacherDegreeService.GetAllTeacherCategories();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<TeacherDegree>, IEnumerable<ViewTeacherDegree>>(teacherCategories);
            logger.Info("Gets Teacher Degree");
            return viewModel;
        }

        // GET api/teacherDegree/5
        public ViewTeacherDegree Get(int id)
        {
            var teacherDegree = teacherDegreeService.GetTeacherDegreeById(id);
            var viewModel = AutoMapper.Mapper.Map<TeacherDegree, ViewTeacherDegree>(teacherDegree);
            return viewModel;

        }

        // POST api/teacherDegree
        public void Post([FromBody]ViewTeacherDegree value)
        {
            var teacherDegree = AutoMapper.Mapper.Map<ViewTeacherDegree, TeacherDegree>(value);
            this.teacherDegreeService.AddTeacherDegree(teacherDegree);
            this.teacherDegreeService.SaveTeacherDegree();

        }

        // PUT api/teacherDegree/5
        [HttpPost]
        public void Put(int id, [FromBody]ViewTeacherDegree value)
        {
            var teacherDegree = teacherDegreeService.GetTeacherDegreeById(id);
            AutoMapper.Mapper.Map<ViewTeacherDegree, TeacherDegree>(value, teacherDegree);
            teacherDegreeService.UpdateTeacherDegree(teacherDegree);
            teacherDegreeService.SaveTeacherDegree();
        }

        // DELETE api/teacherDegree/5
        [HttpDelete]
        public void Delete(int id)
        {
            this.teacherDegreeService.DeleteTeacherDegree(id);
            this.teacherDegreeService.SaveTeacherDegree();
        }
    }
}
