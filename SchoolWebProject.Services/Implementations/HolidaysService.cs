using System;
using System.Collections.Generic;
using System.Linq;
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

        public Holidays GetHolidaysById(int id)
        {
            return this.unitOfWork.HolidaysRepository.GetById(id);
        }

        public IEnumerable<ViewHolidays> GetHolidaysByDate(string date)
        {
            string[] split = date.Split('-');
            DateTime monday = new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
            DateTime friday = monday.AddDays(4);
            var holidays = this.unitOfWork.HolidaysRepository.GetMany(d => (d.StartDay <= friday && d.EndDay >= monday && d.Name != "Semestr1" && d.Name != "Semestr2"));
            List<ViewHolidays> holidaysList = new List<ViewHolidays>(5);
            for (int i = 0; i <= 4; i++)
            {
                var s = holidays.Where(d => (d.StartDay <= monday.AddDays(i) && d.EndDay >= monday.AddDays(i))).FirstOrDefault();
                if (s != null)
                {
                    holidaysList.Add(new ViewHolidays { HolidaysName = s.Name });
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

        public void SaveHolidays()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
