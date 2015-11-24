using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using db = SchoolWebProject.Domain.Models;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services.Models
{
    public class ViewGroup
    {
        public int Id { get; set; }

        public int NameNumber { get; set; }

        public string NameLetter { get; set; }

        public int TeacherId { get; set; }

        public string Teacher { get; set; }

        public int PupilsAmount { get; set; }

        static ViewGroup()
        {
            AutoMapper.Mapper.CreateMap<db.Group, ViewGroup>()
                .IgnoreAllNonExisting()
                .ForMember(
                    dest => dest.TeacherId,
                    opts => opts.MapFrom(src => (
                        ((src.Teacher != null) && (src.Teacher.Count != 0))
                        ? ((db.User)src.Teacher[0]).Id 
                        : 0)))
                .ForMember(
                    dest => dest.Teacher,
                    opts => opts.MapFrom(src => (
                        ((src.Teacher != null) && (src.Teacher.Count != 0))
                        ? ((db.User)src.Teacher[0]).FirstName + " " + ((db.User)src.Teacher[0]).LastName
                        : "немає")))
                .ForMember(
                    dest=>dest.PupilsAmount,
                    opts=>opts.MapFrom(src=>src.Pupils.Count));
        }

        public static ViewGroup CreateSimpleGroup(db.Group g)
        {
            return Mapper.Map<db.Group, ViewGroup>(g);
        }
    }
}