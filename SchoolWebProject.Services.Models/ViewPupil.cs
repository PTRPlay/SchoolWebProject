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

        //public byte[] Img { get; set; }

        //public int GroupId { get; set; }

   //     public string School { get; set; }

        //public int LogInDataId { get; set; }
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