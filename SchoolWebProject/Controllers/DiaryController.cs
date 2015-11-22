using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolWebProject.Controllers
{
    public class DiaryController : BaseApiController
    {
        private IDiaryService diaryService;

        public DiaryController(ILogger logger, IDiaryService diaryService)
            : base(logger)
        {
            this.diaryService = diaryService;
        }
        // GET api/diary
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/diary/id/date
        public IEnumerable<Diary> Get(int id, string date)
        {
            //  throw new NotImplementedException();
            var viewModel = diaryService.GetDiaryByUserId(id, date);
            return viewModel;
        }

        // GET api/diary/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/diary
        public void Post([FromBody]string value)
        {
        }

        // PUT api/diary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/diary/5
        public void Delete(int id)
        {
        }
    }
}
