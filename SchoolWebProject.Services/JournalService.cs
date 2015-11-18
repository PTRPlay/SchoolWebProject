using System;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public class JournalService : BaseService, IJournalService
    {
         private IUnitOfWork unitOfWork;

         public JournalService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
             this.unitOfWork = unitOfWork;
        }

         public ViewJournal GetJournalObject(int groupId, int subjectId)
         {
             throw new NotImplementedException();
         }


 
    }
}
