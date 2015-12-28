using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
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

        public IEnumerable<Diary> GetDiaryByUserId(int idUser, DateTime date)
        {
            logger.Info("Get diary for user. Id = {0}", idUser);
            DateTime monday = date;
            DateTime friday = monday.AddDays(Constants.CountOfWorkingDaysInWeek-1);
            var pupil = this.unitOfWork.PupilRepository.GetById(idUser);
            var schedule = this.unitOfWork.ScheduleRepository.GetMany(s => s.GroupId == pupil.GroupId);
            var lessons = this.unitOfWork.LessonDetailRepository.GetMany(l => l.Date >= monday && l.Date <= friday);
            var marks = this.unitOfWork.MarkRepository.GetMany(m => m.PupilId == idUser);
            var tempDiary = from s in schedule
                            join l in lessons
                            on s.Id equals l.ScheduleId into ppssll
                            orderby s.DayOfTheWeek ascending
                            from l in ppssll.DefaultIfEmpty()
                            select new
                            {
                                IdPupil = pupil.Id,
                                DayOfTheWeek = s.DayOfTheWeek,
                                OrderNumber = s.OrderNumber,
                                SubjectName = this.unitOfWork.SubjectRepository.GetById(s.SubjectId).Name,
                                HomeTask = l == null ? string.Empty : l.HomeTask,
                                LessonTheme = l == null ? string.Empty : l.Theme,
                                Date = l == null ? default(DateTime) : l.Date,
                                LessonDetailId = l == null ? 0 : l.Id
                            };

            var temp = from t in tempDiary
                       join m in marks
                       on t.LessonDetailId equals m.LessonDetailId into ttmm
                       from tm in ttmm.DefaultIfEmpty()
                       select new Diary
                       {
                           IdPupil = t.IdPupil,
                           DayOfTheWeek = t.DayOfTheWeek,
                           OrderNumber = t.OrderNumber,
                           SubjectName = t.SubjectName,
                           HomeTask = t.HomeTask,
                           LessonTheme = t.LessonTheme,
                           Date = t.Date,
                           MarkValue = tm == null ? string.Empty : tm.Value.ToString(),
                           MarkTypeName = tm == null ? string.Empty : this.unitOfWork.MarkTypeRepository.GetById(tm.MarkTypeId).Name
                       };
            return temp;
        }
    }
}
