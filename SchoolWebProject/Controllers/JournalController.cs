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
    public class JournalController : BaseApiController
    {
        private JournalService journalService;

        public JournalController(ILogger logger, JournalService journalService)
            : base(logger) 
        {
            this.journalService = journalService;
        }

        // GET api/diary/5/data
        //public Diary Get(int id, DateTime date)
        public ViewJournal GetJournalPage(int groupId, int subjectId)
        {
          //  throw new NotImplementedException();
            var viewModel = journalService.GetJournalObject(groupId, subjectId);
                 return viewModel;
        }
        

     }
}
