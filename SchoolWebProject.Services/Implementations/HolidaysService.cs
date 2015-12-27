using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services.Models.ViewModels;

namespace SchoolWebProject.Services
{
    public class HolidaysService : BaseService, IHolidaysService
    {
        private ILogger holidaysLogger;

        private IUnitOfWork unitOfWork;

        public HolidaysService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Holidays> GetAllHolidays()
        {
            return this.unitOfWork.HolidaysRepository.GetAll();
        }

        public Holidays GetHolidaysByStartDay(Holidays holidays)
        {
            return this.unitOfWork.HolidaysRepository.Get(h => h.StartDay == holidays.StartDay);
        } 

        public Holidays GetHolidaysById(int id)
        {
            if (id < 0) 
            {
                throw new ArgumentException();
            }
            return this.unitOfWork.HolidaysRepository.GetById(id);
        }

        public IEnumerable<ViewHolidays> GetHolidaysByDate(DateTime date)
        {
            DateTime monday = date;
            DateTime friday = monday.AddDays(Constants.CountOfWorkingDaysInWeek - 1);
            var holidays = this.unitOfWork.HolidaysRepository.GetMany(d => (d.StartDay <= friday && d.EndDay >= monday && d.Name != Constants.FirstSemestrNameInDB  && d.Name != Constants.SecondSemestrNameInDB));
            List<ViewHolidays> holidaysList = new List<ViewHolidays>(Constants.CountOfWorkingDaysInWeek);
            for (int i = 0; i < Constants.CountOfWorkingDaysInWeek; i++)
            {
                var holidayInCurrentDay = holidays.Where(d => (d.StartDay <= monday.AddDays(i) && d.EndDay >= monday.AddDays(i))).FirstOrDefault();
                if (holidayInCurrentDay != null)
                {
                    holidaysList.Add(new ViewHolidays { HolidaysName = holidayInCurrentDay.Name });
                }
                else
                {
                    holidaysList.Add(new ViewHolidays { HolidaysName = string.Empty });
                }

            }
            return holidaysList;
        }

        public void UpdateHolidays(Holidays holidays)
        {
            this.unitOfWork.HolidaysRepository.Update(holidays);
            this.SaveHolidays();
        }

        public void AddHolidays(Holidays holidays)
        {
            this.unitOfWork.HolidaysRepository.Add(holidays);
            this.SaveHolidays();
        }

        public void RemoveHolidays(int id)
        {
            var holidays = this.unitOfWork.HolidaysRepository.GetById(id);
            this.unitOfWork.HolidaysRepository.Delete(holidays);
            this.SaveHolidays();
        }

        private void SaveHolidays()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
