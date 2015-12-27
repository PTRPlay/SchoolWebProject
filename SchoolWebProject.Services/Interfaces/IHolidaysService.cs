using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services.Models.ViewModels;

namespace SchoolWebProject.Services
{
    public interface IHolidaysService
    {
        IEnumerable<Holidays> GetAllHolidays();

        Holidays GetHolidaysById(int id);

        IEnumerable<ViewHolidays> GetHolidaysByDate(DateTime date);

        void UpdateHolidays(Holidays holidays);

        void AddHolidays(Holidays holidays);

        void RemoveHolidays(int id);
    }
}
