﻿using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface IHolidaysService
    {
        IEnumerable<Holidays> GetAllHolidays();

        Holidays GetHolidaysById(int id);

        void UpdateHolidays(Holidays holidays);

        void AddHolidays(Holidays holidays);

        void RemoveHolidays(Holidays holidays);
    }
}
