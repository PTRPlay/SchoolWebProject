using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Models;
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

        public ViewJournal GetJournalPage(int groupId, int subjectId)
        {
            var viewModel = journalService.GetJournalObject(groupId, subjectId);
            return viewModel;
        }
     }
}
