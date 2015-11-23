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
            var pupils = unitOfWork.PupilRepository.GetAll();
            var lessonDetail = unitOfWork.LessonDetailRepository.GetAll();
            var marks = unitOfWork.MarkRepository.GetAll();

            var pupilView = (from p in pupils
                             where p.GroupId == groupId
                             select new ViewPupil
                                 {
                                     Id = p.Id,

                                     FirstName=p.FirstName,

                                     LastName = p.LastName,

                                     MiddleName = p.MiddleName
                                 });

            var lessonDeatailView = from ld in lessonDetail
                                    where ld.Schedule.GroupId == groupId && ld.Schedule.SubjectId == subjectId
                                    select new ViewLessonDetail
                                        {
                                            Id = ld.Id,
                                            HomeTask = ld.HomeTask,
                                            Date = ld.Date,
                                            ScheduleId = ld.ScheduleId,
                                            SchoolId = ld.SchoolId
                                        };

            var marksView = from m in marks
                            where m.Pupil.GroupId == groupId && m.LessonDetail.Schedule.SubjectId == subjectId
                            select new ViewMark
                                {
                                    Id = m.Id,
                                    LessonDetailId = m.LessonDetailId,
                                    SchoolId = m.SchoolId,
                                    Value = m.Value,
                                    MarkTypeId = m.MarkTypeId,
                                    ScheduleId = m.SchoolId,
                                    PupilId=m.PupilId,
                                    FirstName=m.Pupil.FirstName,
                                    LastName=m.Pupil.LastName
                                };

            return new ViewJournal() { Pupils = pupilView, LessonDetails = lessonDeatailView, Marks = marksView };
        }
    }
}


