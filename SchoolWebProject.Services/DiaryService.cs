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

        public IEnumerable<Diary> GetDiaryByUserId(int idUser, string date)
        {
            string[] split = date.Split('-');
            DateTime monday = new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
            DateTime tuesday = monday.AddDays(1);
            DateTime wednesday = monday.AddDays(2);
            DateTime thursday = monday.AddDays(3);
            DateTime friday = monday.AddDays(4);
            var pupil = this.unitOfWork.PupilRepository.GetById(idUser);
            var schedule = this.unitOfWork.ScheduleRepository.GetAll();
            var lessons = this.unitOfWork.LessonDetailRepository.GetAll();
            var marks = this.unitOfWork.MarkRepository.GetAll();

            var tempLessons = from l in lessons
                              where l.Date == monday || l.Date == tuesday || l.Date == wednesday || l.Date == thursday || l.Date == friday
                              select l;

            var tempDiary = from s in schedule
                            where s.GroupId == pupil.GroupId
                            join l in tempLessons
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
                                Date = l == null ? string.Empty : l.Date.ToString(),
                                LessonDetailId = l == null ? 0 : l.Id
                            };
            var tempMark = from m in marks
                           where m.PupilId == idUser
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
                           LessonTheme = t.LessonTheme,
                           Date = t.Date,
                           MarkValue = tm == null ? string.Empty : tm.Value.ToString(),
                           MarkTypeName = tm == null ? string.Empty : this.unitOfWork.MarkTypeRepository.GetById(tm.MarkTypeId).Name
                       };
            return temp;
        }
    }
}
