using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Models;
using AutoMapper;
using System.Web;
using System.Data.Entity;

namespace SchoolWebProject.Controllers
{
    public class TeacherController : ApiController
    {
        
        private ILogger getLogger;

        private TeacherService teacherService;
        private SubjectService subjectService;

        public TeacherController(ILogger logger, TeacherService teacherService , SubjectService subjectService ) 
        {
            this.getLogger = logger;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
        }
        // GET api/teacher
        public IEnumerable<ViewTeacher> Get()
        {
            var teachers = teacherService.GetAllTeachers();
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Teacher>,IEnumerable<ViewTeacher>>(teachers);
            return viewModel;
        }

        // GET api/teacher/5
        public ViewTeacher Get(int id)
        {
            var teacher = teacherService.GetProfileById(id);
            var viewModel = AutoMapper.Mapper.Map<Teacher, ViewTeacher>(teacher);
            return viewModel;
        }

        // POST api/teacher
        public void Post([FromBody]ViewTeacher value)
        {
            var bin = new SchoolContext();
            //Teacher teacher = new Teacher();
            //teacher.Subjects = AutoMapper.Mapper.Map<IEnumerable<ViewSubject>, IEnumerable<Subject>>(value.Subjects).ToList<Subject>();
            var modifiedSubjects = value.Subjects;
            value.Subjects = null;
            //AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value,teacher);
            Teacher teacher = AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value);
            //teacher.Subjects.AddRange(subjects);
            foreach (var subject in modifiedSubjects)
                bin.Subjects.First((p) => p.Id ==subject.Id).Teachers.Add(teacher);
            bin.Entry(teacher).State = EntityState.Added;
            bin.SaveChanges();
            //teacherService.AddTeacher(teacher);
        }

        // PUT api/teacher/5
        [HttpPost]
        public void Put(int id, [FromBody]ViewTeacher value)
        {
            var bin = new SchoolContext();

            var teacher = teacherService.GetProfileById(value.Id);
            AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value,(Teacher)teacher);

            bin.Entry((Teacher)teacher).State = EntityState.Modified;
            bin.SaveChanges();
            //teacherService.UpdateProfile(teacher);
        }

        // DELETE api/teacher/5
        public void Delete(int id)
        {
        }
    }
}
