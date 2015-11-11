using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Models;

namespace SchoolWebProject.Mapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }

    public class DomainToViewModelMappingProfile : Profile
    {
        public string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<Announcement, ViewAnnouncement>();
            AutoMapper.Mapper.CreateMap<Pupil, ViewPupil>();
            AutoMapper.Mapper.CreateMap<Teacher, ViewTeacher>()
                .ForMember(g => g.Category, map => map.MapFrom(vm => vm.TeacherCategory))
                .ForMember(g => g.Degree, map => map.MapFrom(vm => vm.TeacherDegree));
            AutoMapper.Mapper.CreateMap<TeacherCategory, ViewTeacherCategory>();
            AutoMapper.Mapper.CreateMap<TeacherDegree, ViewTeacherDegree>();
            AutoMapper.Mapper.CreateMap<Subject, ViewSubject>();
            AutoMapper.Mapper.CreateMap<School, ViewSchool>();
        }
    }

    public class ViewModelToDomainMappingProfile : Profile
    {
        public string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<ViewTeacherCategory,TeacherDegree>();
            AutoMapper.Mapper.CreateMap<ViewTeacherDegree,TeacherDegree>();
            AutoMapper.Mapper.CreateMap<ViewSchool,School>();
            
            AutoMapper.Mapper.CreateMap<ViewTeacher, Teacher>()
                .ForMember(g => g.TeacherCategory, map => map.MapFrom(vm => vm.Category))
                .ForMember(g => g.TeacherDegree, map => map.MapFrom(vm => vm.Degree));

            AutoMapper.Mapper.CreateMap<ViewPupil, Pupil>()
                .ForMember(g => g.FirstName, map => map.MapFrom(vm => vm.FirstName))
                .ForMember(g => g.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(g => g.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(g => g.Image, map => map.MapFrom(vm => vm.Image))
                .ForMember(g => g.LastName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(g => g.MiddleName, map => map.MapFrom(vm => vm.MiddleName))
                .ForMember(g => g.PhoneNumber, map => map.MapFrom(vm => vm.PhoneNumber));
                //.ForMember(g => g.School, map => map.MapFrom(vm => vm.School));

            AutoMapper.Mapper.CreateMap<ViewAnnouncement, Announcement>()
                .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                .ForMember(g => g.Message, map => map.MapFrom(vm => vm.Message))
                .ForMember(g => g.MessageDetails, map => map.MapFrom(vm => vm.MessageDetails))
                .ForMember(g => g.Image, map => map.MapFrom(vm => vm.Image))
                .ForMember(g => g.DataPublished, map => map.MapFrom(vm => vm.DataPublished));

            AutoMapper.Mapper.CreateMap<ViewTeacherCategory, TeacherCategory>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name));

            AutoMapper.Mapper.CreateMap<ViewSubject, Subject>();
        }
    }
}