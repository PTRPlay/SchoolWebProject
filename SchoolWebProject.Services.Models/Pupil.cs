using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using db = SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services.Models
{
    public class Pupil
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public byte[] Image { get; set; }

        static Pupil()
        {
            Mapper.CreateMap<db.Pupil, Pupil>().IgnoreAllNonExisting();
        }

        public static Pupil CreateSimplePupil(db.Pupil p)
        {
            return Mapper.Map<db.Pupil, Pupil>(p);
        }

    }
}
