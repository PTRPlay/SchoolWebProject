using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

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
