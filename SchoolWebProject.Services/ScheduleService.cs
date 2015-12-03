using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services 
{
    public class ScheduleService : BaseService, IScheduleService
    {

        private IUnitOfWork unitOfWork;

        public ScheduleService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
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
            if (teacher == "null")
            {
                if (group != "null")
                {
                    return groupSchedule;
                }
            }
            else 
            {
                if (group == "null") 
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
        
        public void UpdateSchedule(Schedule schedule)
        {
            this.unitOfWork.ScheduleRepository.Update(schedule);
        }

        public void AddSchedule(Schedule schedule)
        {
            this.unitOfWork.ScheduleRepository.Add(schedule);
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
