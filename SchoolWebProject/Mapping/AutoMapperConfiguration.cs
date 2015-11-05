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
            AutoMapper.Mapper.CreateMap<Teacher,ViewTeacher>();
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
            AutoMapper.Mapper.CreateMap<ViewTeacher, Teacher>()
                .ForMember(g => g.FirstName, map => map.MapFrom(vm => vm.firstName))
                //.ForMember(g => g.Address, map => map.MapFrom(vm => vm.Address))
                //.ForMember(g => g.Email, map => map.MapFrom(vm => vm.Email))
                //.ForMember(g => g.Image, map => map.MapFrom(vm => vm.Image))
                .ForMember(g => g.LastName, map => map.MapFrom(vm => vm.lastName))
                .ForMember(g => g.MiddleName, map => map.MapFrom(vm => vm.middleName));
                //.ForMember(g=>g.PhoneNumber,map => map.MapFrom(vm => vm.phoneNumber))
                //.ForMember(g => g.School, map => map.MapFrom(vm => vm.School));
        }
    }

}