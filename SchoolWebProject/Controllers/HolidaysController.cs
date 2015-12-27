using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models.ViewModels;

namespace SchoolWebProject.Controllers
{
    public class HolidaysController : BaseApiController
    {
        private IHolidaysService holidaysService;

        public HolidaysController(ILogger logger, IHolidaysService holidaysService)
            : base(logger)
        {
            this.holidaysService = holidaysService;
        }

        // GET api/holidays
        public IEnumerable<Holidays> Get()
        {
            return this.holidaysService.GetAllHolidays();
        }

        // GET api/holidays/5
        public IEnumerable<ViewHolidays> Get(DateTime date)
        {
            return this.holidaysService.GetHolidaysByDate(date);
        }


        [Authorize(Roles = "Admin")]
        // POST api/holidays
        public void Post([FromBody]Holidays value)
        {
            this.holidaysService.AddHolidays(value);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody]Holidays value)
        {
            this.holidaysService.UpdateHolidays(value);
        }

        // DELETE: api/holidays/5
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            this.holidaysService.RemoveHolidays(id);
        }
    }
}
