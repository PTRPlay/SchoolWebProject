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
        private IRepository<Schedule> repository;

        private IUnitOfWork unitOfWork;

        public ScheduleService(ILogger logger, IRepository<Schedule> scheduleRepository, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.repository = scheduleRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return this.repository.GetAll();
        }

        public Schedule GetScheduleById(int id)
        {
            return this.repository.GetById(id);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            this.repository.Update(schedule);
        }

        public void AddSchedule(Schedule schedule)
        {
            this.repository.Add(schedule);
        }

        public void RemoveSchedule(Schedule schedule)
        {
            this.repository.Delete(schedule);
        }

        public void SaveSchedule()
        {
            unitOfWork.SaveChanges();
        }
    }
}
