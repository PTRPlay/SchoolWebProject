using System;
using SchoolWebProject.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface IScheduleService
    {
        IEnumerable<Schedule> GetAllSchedules();

        Schedule GetScheduleById(int id);

        IEnumerable<Subject> GetSubjectForGroupByGroupId(int GroupId);

        IEnumerable<Schedule> GetByFilter(int teacherFK ,int groupFK);

        //void UpdateSchedule(Schedule mark);

        void ModifySchedule(IEnumerable<Schedule> mark);

        void RemoveSchedule(Schedule mark);

        void SaveSchedule();
    }
}
