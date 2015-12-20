using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using db = SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services.Models
{
    public class ViewPupil
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string GroupNumber { get; set; }

        public string GroupLetter { get; set; }

        public int GroupId { get; set; }

        static ViewPupil()
        {
            Mapper.CreateMap<db.Pupil, ViewPupil>().IgnoreAllNonExisting();
        }

        public static ViewPupil CreateSimplePupil(db.Pupil p)
        {
            return Mapper.Map<db.Pupil, ViewPupil>(p);
        }
    }
}