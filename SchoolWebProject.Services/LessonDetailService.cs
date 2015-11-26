using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<LessonDetail> GetAllLessonDetails()
        {
            return this.unitOfWork.LessonDetailRepository.GetAll();
        }

        public LessonDetail GetLessonDetailById(int id)
        {
            return this.unitOfWork.LessonDetailRepository.GetById(id);
        }

        public void UpdateLessonDetail(LessonDetail lessonDetail)
        {
            this.unitOfWork.LessonDetailRepository.Update(lessonDetail);
        }

        public void AddLessonDetail(LessonDetail lessonDetail)
        {
            this.unitOfWork.LessonDetailRepository.Add(lessonDetail);
        }

        public void RemoveLessonDetail(LessonDetail lessonDetail)
        {
            this.unitOfWork.LessonDetailRepository.Delete(lessonDetail);
        }

        public void SaveLessonDetail()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
