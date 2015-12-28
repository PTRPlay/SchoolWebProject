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
        private ILessonDetailService lessonDetailService;

        public ScheduleService(ILogger logger, IUnitOfWork unitOfWork, ITeacherService teacherService, ISubjectService subjectService, IGroupService groupService, ILessonDetailService lessonDetail)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
            this.groupService = groupService;
            this.lessonDetailService = lessonDetail;
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return this.unitOfWork.ScheduleRepository.GetAll();
        }

        public IEnumerable<Schedule> GetByFilter(int teacherFK, int groupFK)
        {

            var groupSchedule = this.unitOfWork.ScheduleRepository.GetMany(g => g.GroupId == groupFK);
            var teacherSchedule = this.unitOfWork.ScheduleRepository.GetMany(g => g.TeacherId == teacherFK);
            if (teacherSchedule.Count() == 0)
            {

                return groupSchedule;
            }
            else
            {
                if (groupFK == 0)
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

        private void UpdateSchedule(Schedule findedSchedule, Schedule schedule)
        {
            findedSchedule.TeacherId = teacherService.GetIdByName(schedule.Teacher.FirstName, schedule.Teacher.LastName, schedule.Teacher.MiddleName);
            findedSchedule.SubjectId = subjectService.GetAllSubjects().FirstOrDefault(s => s.Name == schedule.Subject.Name).Id;
            this.unitOfWork.ScheduleRepository.Update(findedSchedule);
        }

        private void AddSchedule(Schedule schedule)
        {
            schedule.TeacherId = this.teacherService.GetIdByName(schedule.Teacher.FirstName, schedule.Teacher.LastName, schedule.Teacher.MiddleName);
            schedule.SubjectId = subjectService.GetAllSubjects().FirstOrDefault(s => s.Name == schedule.Subject.Name).Id;
            schedule.ClassRoomId = unitOfWork.ClassRoomRepository.GetMany(c => c.Name == schedule.ClassRoom.Name).First().Id;

            schedule.Teacher = null;
            schedule.Subject = null;
            schedule.ClassRoom = null;

            unitOfWork.ScheduleRepository.Add(schedule);
            SaveSchedule();
            Schedule getedSchedule = unitOfWork.ScheduleRepository.GetMany(s => s.TeacherId == schedule.TeacherId && s.SubjectId == schedule.SubjectId && s.GroupId == schedule.GroupId).First();
            this.lessonDetailService.GenereteLessonDeatail(getedSchedule);
        }

        public void ModifySchedule(IEnumerable<Schedule> schedules)
        {
            var allSchedules = GetAllSchedules();
            foreach (var schedule in schedules)
            {
                var findedSchedule = allSchedules.FirstOrDefault(s => s.DayOfTheWeek == schedule.DayOfTheWeek
                                                            && s.OrderNumber == schedule.OrderNumber
                                                            && s.GroupId == schedule.GroupId);
                if (findedSchedule != null)
                {
                    if (schedule.Teacher.FirstName == "")
                    {
                        RemoveSchedule(findedSchedule);
                    }
                    else
                    {
                        UpdateSchedule(findedSchedule, schedule);
                        SaveSchedule();
                        findedSchedule = allSchedules.FirstOrDefault(s => s.DayOfTheWeek == schedule.DayOfTheWeek
                                                            && s.OrderNumber == schedule.OrderNumber);
                        this.lessonDetailService.GenereteLessonDeatail(findedSchedule);
                    }
                }
                else if (schedule.Teacher.FirstName != "")
                {
                    AddSchedule(schedule);
                    Schedule getedSchedule = unitOfWork.ScheduleRepository.GetMany(s => s.TeacherId == schedule.TeacherId && s.SubjectId == schedule.SubjectId && s.GroupId == schedule.GroupId).First();
                    this.lessonDetailService.GenereteLessonDeatail(getedSchedule);
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
