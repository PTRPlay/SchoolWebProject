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
    public class DiaryService : BaseService, IDiaryService
    {
         private IUnitOfWork unitOfWork;

        public DiaryService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
             this.unitOfWork = unitOfWork;
        }

        //public Diary GetDiaryByUserId(int IdUser, DateTime data)
        public IEnumerable<Diary> GetDiaryByUserId(int IdUser)
        {
            var pupils = unitOfWork.PupilRepository.GetAll();
            var schedule = unitOfWork.ScheduleRepository.GetAll();
            var lessons = unitOfWork.LessonDetailRepository.GetAll();
            var marks = unitOfWork.MarkRepository.GetAll();

            var tempDiary = (from p in pupils
                             join s in schedule
                             on p.GroupId equals s.GroupId
                             join l in lessons
                             on s.Id equals l.ScheduleId into ppssll
                             where p.Id == IdUser
                             orderby s.DayOfTheWeek ascending
                             from l in ppssll.DefaultIfEmpty()
                             select new
                             {
                                 IdPupil = p.Id,
                                 DayOfTheWeek = s.DayOfTheWeek,
                                 OrderNumber = s.OrderNumber,
                                 SubjectName = unitOfWork.SubjectRepository.GetById(s.SubjectId).Name,
                                 HomeTask = (l == null ? String.Empty : l.HomeTask),
                                 Date = (l == null ? String.Empty : l.Date.ToString()),
                                 LessonDetailId = (l == null ? 0 : l.Id)
                             });
            var tempMark = from m in marks
                           where m.PupilId == IdUser
                           select m;

            var temp = from t in tempDiary
                       join m in tempMark
                       on t.LessonDetailId equals m.LessonDetailId into ttmm
                       from tm in ttmm.DefaultIfEmpty()
                       select new Diary
                       {
                           IdPupil = t.IdPupil,
                           DayOfTheWeek = t.DayOfTheWeek,
                           OrderNumber = t.OrderNumber,
                           SubjectName = t.SubjectName,
                           HomeTask = t.HomeTask,
                           Date = t.Date,
                           MarkValue = (tm == null ? String.Empty : tm.Value.ToString()),
                           MarkTypeName = (tm == null ? String.Empty : unitOfWork.MarkTypeRepository.GetById(tm.MarkTypeId).Name)
                       };

            return temp;
        }


 
    }
}
