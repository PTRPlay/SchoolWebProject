using System;
using SchoolWebProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Controllers
{
    public class DiaryController : ApiController
    {
        private ILogger getLogger;
        private IDiaryService diaryService;

        public DiaryController(ILogger logger, IDiaryService diaryService) 
        {
            this.getLogger = logger;
            this.diaryService = diaryService;
        }
        // GET api/diary/5/data
        //public Diary Get(int id, DateTime date)
        public IEnumerable<Diary> Get(int id)
        {
          //  throw new NotImplementedException();
            var viewModel = diaryService.GetDiaryByUserId(id);
                 return viewModel;
        }
        

     }
}
