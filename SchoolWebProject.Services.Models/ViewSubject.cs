using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using db = SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services.Models
{
    public class ViewSubject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ViewTeacher1> ViewTeachers { get; set; }

        static ViewSubject()
        {
            Mapper.CreateMap<db.Subject, ViewSubject>().IgnoreAllNonExisting();

            AutoMapper.Mapper.CreateMap<ViewSubject, db.Subject>()
                .IgnoreAllNonExisting();
            //.ForMember(dest => dest.SchoolId, opts => opts.MapFrom(src => 1));
        }

        public static ViewSubject CreateSimpleSubject(db.Subject s)
        {
            ViewSubject temp = Mapper.Map<db.Subject, ViewSubject>(s);
            List<ViewTeacher1> teachers = new List<ViewTeacher1>();
            ViewTeacher1 t = new ViewTeacher1();

            if (s.Teachers != null)
            {
                foreach (var v in s.Teachers)
                {
                    if (v.SchoolId == 1)
                        teachers.Add(Mapper.Map<db.Teacher, ViewTeacher1>(v));
                }

                temp.ViewTeachers = teachers;
            }

            return temp;
        }

        public static db.Subject CreateEntitySubject(ViewSubject vs)
        {
            db.Subject temp = null;

            //to do: not to lose list of ef teachers

            return temp;
        }
    }
}
