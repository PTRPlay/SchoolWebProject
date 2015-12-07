using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using db = SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services.Models
{

    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public byte[] Image { get; set; }

        public DateTime WorkBegin { get; set; }

        static Teacher()
        {
            Mapper.CreateMap<db.Teacher, Teacher>().IgnoreAllNonExisting();
        }

        public static Teacher CreateSimpleTeacher(db.Teacher t)
        {            
            return Mapper.Map<db.Teacher, Teacher>(t);
        }

        
    }
    
}

 