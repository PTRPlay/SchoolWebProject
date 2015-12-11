using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Services.Interfaces;
using AutoMapper;

namespace SchoolWebProject.Services 
{
    public class ScheduleService : BaseService, IScheduleService
    {

        private IUnitOfWork unitOfWork;
        private ITeacherService teacherService;
        private ISubjectService subjectService;
        private IGroupService groupService;

        public ScheduleService(ILogger logger, IUnitOfWork unitOfWork,ITeacherService teacherService ,ISubjectService subjectService,IGroupService groupService)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
            this.groupService = groupService;
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return this.unitOfWork.ScheduleRepository.GetAll();
        }

        public IEnumerable<Schedule> GetByFilter(string teacher, string group)
        {
            
            var groupSchedule = this.unitOfWork.ScheduleRepository.
                GetMany(p => p.Group.NameNumber + "-" + p.Group.NameLetter == group );
            var teacherSchedule = this.unitOfWork.ScheduleRepository.
                GetMany(p => p.Teacher.FirstName + p.Teacher.MiddleName + p.Teacher.LastName == teacher);
            if (teacher == null)
            {
                if (group != null)
                {
                    return groupSchedule;
                }
            }
            else 
            {
                if (group == null) 
                {
                    return teacherSchedule;
                }
            }
            
            return groupSchedule.Intersect(teacherSchedule);
        }
        
        public Schedule GetScheduleById(int id)
        {
            return this.unitOfWork.ScheduleRepository.GetById(id);
        }

        public IEnumerable<Subject> GetSubjectForGroupByGroupId(int GroupId)
        {
            var subjects = this.unitOfWork.ScheduleRepository.GetMany(s => s.GroupId == GroupId).Select(s => s.Subject);
            var unicSubject = subjects.Distinct();
            return unicSubject;
        }
        
        private void updateSchedule(Schedule findedSchedule , Schedule schedule)
        {
            findedSchedule.TeacherId = teacherService.GetIdByName(schedule.Teacher.FirstName, schedule.Teacher.LastName, schedule.Teacher.MiddleName);
            findedSchedule.SubjectId = subjectService.GetAllSubjects().FirstOrDefault(s => s.Name == schedule.Subject.Name).Id;
            this.unitOfWork.ScheduleRepository.Update(findedSchedule);
        }

        private void addSchedule(Schedule schedule)
        {
            schedule.TeacherId = teacherService.GetIdByName(schedule.Teacher.FirstName, schedule.Teacher.LastName, schedule.Teacher.MiddleName);
            schedule.SubjectId = subjectService.GetAllSubjects().FirstOrDefault(s => s.Name == schedule.Subject.Name).Id;
            schedule.ClassRoomId = 1;
            schedule.GroupId = groupService.GetAllGroups().FirstOrDefault(g => g.NameLetter == schedule.Group.NameLetter 
                                                                            && g.NameNumber == schedule.Group.NameNumber).Id;
            schedule.Teacher = null;
            schedule.Subject = null;
            schedule.Group = null;
            schedule.ClassRoom = null;
            unitOfWork.ScheduleRepository.Add(schedule);    
        }
        
        public void ModifySchedule(IEnumerable<Schedule> schedules)
        {
            var allSchedules = GetAllSchedules();
            foreach (var schedule in schedules)
            {
                var findedSchedule = allSchedules.FirstOrDefault(s => s.DayOfTheWeek == schedule.DayOfTheWeek 
                                                            && s.OrderNumber == schedule.OrderNumber 
                                                            && s.Group.NameLetter == schedule.Group.NameLetter
                                                            && s.Group.NameNumber == schedule.Group.NameNumber);
                if (findedSchedule != null)
                {
                    if (schedule.Teacher.FirstName == "")
                    {
                        RemoveSchedule(findedSchedule);
                    }
                    else
                    {
                        updateSchedule(findedSchedule, schedule);
                    }
                }
                else if (schedule.Teacher.FirstName!="")
                {
                    addSchedule(schedule);
                }
            }
            unitOfWork.SaveChanges();
        }

        public void RemoveSchedule(Schedule schedule)
        {
            this.unitOfWork.ScheduleRepository.Delete(schedule);
        }

        public void SaveSchedule()
        {
            unitOfWork.SaveChanges();
        }
    }
}
