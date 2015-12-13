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
    public class LessonDetailService : BaseService, ILessonDetailService
    {
        private IUnitOfWork unitOfWork;

        public LessonDetailService(ILogger logger, IUnitOfWork lessonDetailUnitOfWork)
            : base(logger)
        {
            this.unitOfWork = lessonDetailUnitOfWork;
        }

        public IEnumerable<ViewLessonDetail> GetAllLessonDetails()
        {
            var  lessonDetails =  this.unitOfWork.LessonDetailRepository.GetAll();
            var viewModel  = AutoMapper.Mapper.Map<IEnumerable<LessonDetail>, IEnumerable<ViewLessonDetail>>(lessonDetails);
            return viewModel;
        }

        public ViewLessonDetail GetLessonDetailById(int id)
        {
            var lessonDetail = this.unitOfWork.LessonDetailRepository.GetById(id);
            var viewModel = AutoMapper.Mapper.Map<LessonDetail, ViewLessonDetail>(lessonDetail);
            return viewModel;
        }

        public void UpdateLessonDetail(LessonDetail value)
        {
            this.unitOfWork.LessonDetailRepository.Update(value);
            this.SaveLessonDetail();
        }

        public void GenereteLessonDeatail(Schedule addedSchedule)
        {
            bool IsLessonDateInHolidays = false;
            var holidays = unitOfWork.HolidaysRepository.GetAll();
            var IsExistLessonDetalis = this.unitOfWork.LessonDetailRepository.GetMany(p => p.ScheduleId == addedSchedule.Id);
            DateTime DataOfLesson;
            DateTime StartTerm = new DateTime(2015, 09, 1);
            DateTime EndTerm = new DateTime(2015, 12, 30);
            DateTime FirstDateOfLesson=StartTerm;
            LessonDetail NewLessonDetail;
                do
                {
                    if ((int)StartTerm.DayOfWeek == addedSchedule.DayOfTheWeek)
                    {
                        FirstDateOfLesson = StartTerm;
                        break;
                    }
                    else
                    {
                        StartTerm = StartTerm.AddDays(1);
                    }
                } while (StartTerm < EndTerm);
               
            if (IsExistLessonDetalis.Count() == 0)
            {
                DataOfLesson = FirstDateOfLesson;
                do
                {
                    IsLessonDateInHolidays = false;
                    
                    foreach (var holiday in holidays)
                    {
                        if (holiday.Name.Contains("Semestr")==false)
                        {
                            if (DataOfLesson > holiday.StartDay && DataOfLesson < holiday.EndDay)
                            {
                                IsLessonDateInHolidays = true;
                                break;
                            }
                        }
                    }
                    if(!IsLessonDateInHolidays)
                    {
                        NewLessonDetail = new LessonDetail { ScheduleId = addedSchedule.Id, Date = DataOfLesson, SchoolId = 1 };
                        this.unitOfWork.LessonDetailRepository.Add(NewLessonDetail);
                        SaveLessonDetail();
                    }
                    DataOfLesson = DataOfLesson.AddDays(7);
                } while (DataOfLesson <= EndTerm);
            }
            else
            {
                foreach (var lessonDetail in IsExistLessonDetalis)
                {
                    lessonDetail.ScheduleId = addedSchedule.Id;
                    UpdateLessonDetail(lessonDetail);
                    SaveLessonDetail();
                }
                
            }
        }

        public void AddLessonDetail(ViewLessonDetail value)
        {
            var lessonDetail = AutoMapper.Mapper.Map<ViewLessonDetail, LessonDetail>(value);
            this.unitOfWork.LessonDetailRepository.Add(lessonDetail);
            this.SaveLessonDetail();
        }

        public void SaveLessonDetail()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
