using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;

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

        // GET api/diary/id/date
        public IEnumerable<Diary> Get(int id, DateTime date)
        {
            var viewModel = this.diaryService.GetDiaryByUserId(id, date);
            return viewModel;
        }
    }
}
