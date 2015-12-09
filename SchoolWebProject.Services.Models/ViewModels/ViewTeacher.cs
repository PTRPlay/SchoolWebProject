using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using db = SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services.Models
{
    public class ViewTeacher
    {
        public int Id { get; set; }

        public byte[] Img { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public ViewTeacherCategory Category { get; set; }

        public ViewTeacherDegree Degree { get; set; }

        public string WorkStart { get; set; }

        public IEnumerable<ViewSubject> Subjects { get; set; }

        static ViewTeacher()
        {
            Mapper.CreateMap<db.Teacher, ViewTeacher>().IgnoreAllNonExisting();
        }

        public static ViewTeacher CreateSimpleTeacher(db.Teacher t)
        {
            return Mapper.Map<db.Teacher, ViewTeacher>(t);
        }
    }
}
