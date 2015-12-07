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

        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<Announcement, ViewAnnouncement>();
            AutoMapper.Mapper.CreateMap<Pupil, ViewPupil>();
            AutoMapper.Mapper.CreateMap<Teacher, ViewTeacher>()
                .ForMember(g => g.Category, map => map.MapFrom(vm => vm.TeacherCategory))
                .ForMember(g => g.WorkStart, map => map.MapFrom(vm => Convert.ToString(vm.WorkBegin)));
            AutoMapper.Mapper.CreateMap<TeacherCategory, ViewTeacherCategory>();
            AutoMapper.Mapper.CreateMap<TeacherDegree, ViewTeacherDegree>();
            AutoMapper.Mapper.CreateMap<Subject, ViewSubject>();
            AutoMapper.Mapper.CreateMap<Mark, ViewMark>()
                .ForMember(g => g.LessonDetail, map => map.MapFrom(vm => vm.LessonDetail));
            AutoMapper.Mapper.CreateMap<School, ViewSchool>();
            AutoMapper.Mapper.CreateMap<LessonDetail, ViewLessonDetail>();
            AutoMapper.Mapper.CreateMap<Schedule, ViewSchedule>()
                .ForMember(g => g.Group, map => map.MapFrom(vm => vm.Group.NameNumber + "-" + vm.Group.NameLetter));
        }
    }

    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<ViewTeacherCategory, TeacherDegree>();
            AutoMapper.Mapper.CreateMap<ViewTeacherDegree, TeacherDegree>();

            AutoMapper.Mapper.CreateMap<ViewTeacher, Teacher>()
                .ForMember(g => g.TeacherCategoryId, map => map.MapFrom(vm => vm.Category.Id))
                .ForMember(g => g.TeacherDegreeId, map => map.MapFrom(vm => vm.Degree.Id))
                .ForMember(g => g.WorkBegin, map => map.MapFrom(vm => Convert.ToDateTime(vm.WorkStart)))
                .ForMember(g => g.Address, map => map.MapFrom(vm => vm.Address))
                .ForMember(g => g.PhoneNumber, map => map.MapFrom(vm => vm.PhoneNumber))
                .ForMember(g => g.Email, map => map.MapFrom(vm => vm.Email));

            AutoMapper.Mapper.CreateMap<ViewMark, Mark>()
                 .ForMember(g => g.SchoolId, map => map.MapFrom(vm => 1))
                 .ForMember(g => g.MarkTypeId, map => map.MapFrom(vm => 2));

            AutoMapper.Mapper.CreateMap<ViewPupil, Pupil>();

            AutoMapper.Mapper.CreateMap<ViewAnnouncement, Announcement>();

            AutoMapper.Mapper.CreateMap<ViewTeacherCategory, TeacherCategory>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name));
            AutoMapper.Mapper.CreateMap<ViewLessonDetail, LessonDetail>();
            AutoMapper.Mapper.CreateMap<ViewSubject, Subject>();
            AutoMapper.Mapper.CreateMap<ViewSchool, School>();
            AutoMapper.Mapper.CreateMap<ViewSchedule, Schedule>()
                .ForMember(g => g.Group, map => map.MapFrom(vm => ParseStringIntoGroup(vm.Group)))
                .ForMember(g => g.SchoolId, map => map.MapFrom(vm => 1));
        }
        public Group ParseStringIntoGroup(string info)
        {
            Group group = new Group();
            group.NameLetter = info.Split('-')[1];
            group.NameNumber = Convert.ToInt32(info.Split('-')[0]);
            return group;
        }
    }

}