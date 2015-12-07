using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services.Models
{
    public class ViewGroup
    {
        public int Id { get; set; }

        public int NameNumber { get; set; }

        public string NameLetter { get; set; }

        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

        public int PupilsAmount { get; set; }

        public List<ViewPupil> ViewPupils { get; set; }

        public int SchoolId { get; set; }

        //static ViewGroup()
        //{
        //    AutoMapper.Mapper.CreateMap<Group, ViewGroup>()
        //        .IgnoreAllNonExisting()
        //        .ForMember(
        //            dest => dest.TeacherId,
        //            opts => opts.MapFrom(src => (
        //                ((src.Teacher != null) && (src.Teacher.Count != 0))
        //                ? ((User)src.Teacher[0]).Id
        //                : 0)))
        //        .ForMember(
        //            dest => dest.TeacherName,
        //            opts => opts.MapFrom(src => (
        //                ((src.Teacher != null) && (src.Teacher.Count != 0))
        //                ? ((User)src.Teacher[0]).FirstName + " " + ((User)src.Teacher[0]).MiddleName + " " + ((User)src.Teacher[0]).LastName
        //                : "немає")))
        //        .ForMember(
        //            dest => dest.PupilsAmount,
        //            opts => opts.MapFrom(src => src.Pupils.Count));

        //    AutoMapper.Mapper.CreateMap<ViewGroup, Group>()
        //        .IgnoreAllNonExisting()
        //        .ForMember(dest => dest.SchoolId, opts => opts.MapFrom(src => 1));
        //}

        public static ViewGroup CreateSimpleGroup(Group g)
        {
            ViewGroup temp = Mapper.Map<Group, ViewGroup>(g);
            List<ViewPupil> pupils = new List<ViewPupil>();
            ViewPupil p = new ViewPupil();

            if (g.Pupils != null)
            {
                foreach (var v in g.Pupils)
                    pupils.Add(Mapper.Map<SchoolWebProject.Domain.Models.Pupil, ViewPupil>(v));

                temp.ViewPupils = pupils;
            }

            return temp;
        }
    }
}