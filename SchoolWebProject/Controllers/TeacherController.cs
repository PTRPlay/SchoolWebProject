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
            SchoolContext bin = new SchoolContext();
            var modifiedSubjects = value.Subjects;
            value.Subjects = null;
            Teacher teacher = AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value);
            foreach (var subject in modifiedSubjects)
                bin.Subjects.First((p) => p.Id == subject.Id).Teachers.Add(teacher);
            bin.SaveChanges();
        }

        // PUT api/teacher/5
        [HttpPost]
        public void Put(int id, [FromBody]ViewTeacher value)
        {
            SchoolContext bin = new SchoolContext();
            Teacher teacher = (Teacher)bin.Users.First(p => p.Id == value.Id);
            IEnumerable<Subject> subjects = AutoMapper.Mapper.Map<IEnumerable<ViewSubject>, IEnumerable<Subject>>(value.Subjects);
            value.Subjects = null;
            AutoMapper.Mapper.Map<ViewTeacher, Teacher>(value, teacher);
            foreach (Subject subject in subjects)
            { 
                if (bin.Subjects.First((p) => p.Id == subject.Id) != null)
                {
                    teacher.Subjects.Add(bin.Subjects.First((p) => p.Id==subject.Id));
                }
            }

            bin.SaveChanges();
       }

        // DELETE api/teacher/5
        public void Delete(int id)
        {
        }
    }
}
