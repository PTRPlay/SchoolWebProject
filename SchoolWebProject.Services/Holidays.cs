using System;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public class HolidaysService : BaseService, IHolidaysService
    {

        private ILogger holidaysLogger;

        private IUnitOfWork unitOfWork;

        public HolidaysService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.holidaysLogger = logger;
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
        }

        public void AddHolidays(Holidays holidays)
        {
            this.unitOfWork.HolidaysRepository.Add(holidays);
            this.unitOfWork.SaveChanges();
        }

        public void RemoveHolidays(Holidays holidays)
        {
            this.unitOfWork.HolidaysRepository.Delete(holidays);
        }
    }
}
