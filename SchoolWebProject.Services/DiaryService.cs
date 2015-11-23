using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Services.Models;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

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

        public IEnumerable<Diary> GetDiaryByUserId(int IdUser, string date)
        {
            string[] split = date.Split('-');
            DateTime monday = new DateTime(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]));
            DateTime tuesday = monday.AddDays(1);
            DateTime wednesday = monday.AddDays(2);
            DateTime thursday = monday.AddDays(3);
            DateTime friday = monday.AddDays(4);
            var pupil = unitOfWork.PupilRepository.GetById(IdUser);
            var schedule = unitOfWork.ScheduleRepository.GetAll();
            var lessons = unitOfWork.LessonDetailRepository.GetAll();
            var marks = unitOfWork.MarkRepository.GetAll();

            var tempLessons = from l in lessons
                              where l.Date == monday || l.Date == tuesday || l.Date == wednesday || l.Date == thursday || l.Date == friday
                              select l;

            var tempDiary = from s in schedule
                            where s.GroupId == pupil.GroupId // && s.DayOfTheWeek == (int)d.DayOfWeek
                            join l in tempLessons
                            on s.Id equals l.ScheduleId into ppssll
                            orderby s.DayOfTheWeek ascending
                            from l in ppssll.DefaultIfEmpty()
                            select new
                            {
                                IdPupil = pupil.Id,
                                DayOfTheWeek = s.DayOfTheWeek,
                                OrderNumber = s.OrderNumber,
                                SubjectName = unitOfWork.SubjectRepository.GetById(s.SubjectId).Name,
                                HomeTask = l == null ? String.Empty : l.HomeTask,
                                LessonTheme = (l == null ? String.Empty : l.Theme),
                                Date = (l == null ? String.Empty : l.Date.ToString()),
                                LessonDetailId = (l == null ? 0 : l.Id)
                            };
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
                           LessonTheme = t.LessonTheme,
                           Date = t.Date,
                           MarkValue = (tm == null ? String.Empty : tm.Value.ToString()),
                           MarkTypeName = (tm == null ? String.Empty : unitOfWork.MarkTypeRepository.GetById(tm.MarkTypeId).Name)
                       };
            return temp;
        }
    }
}
