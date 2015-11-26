using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using db = SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services.Models
{
    public class ViewTeacher1
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        static ViewTeacher1()
        {
            Mapper.CreateMap<db.Teacher, ViewTeacher1>().IgnoreAllNonExisting();
        }

        public static ViewTeacher1 CreateSimpleTeacher(db.Teacher t)
        {
            return Mapper.Map<db.Teacher, ViewTeacher1>(t);
        }
    }
}
