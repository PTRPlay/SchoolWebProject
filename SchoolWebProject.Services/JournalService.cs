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
             var pupils =unitOfWork.PupilRepository.GetAll().Where(p=>p.GroupId==groupId);
             var lessonDetail = unitOfWork.LessonDetailRepository.GetAll().Where(p => p.Schedule.GroupId == groupId && p.Schedule.SubjectId == subjectId);
             var marks = unitOfWork.MarkRepository.GetAll().Where(p => p.Pupil.GroupId == groupId && p.LessonDetail.Schedule.SubjectId == subjectId);
             return new ViewJournal() { Pupils=pupils,LessonDetails=lessonDetail, Marks=marks};
         }


 
    }
}
