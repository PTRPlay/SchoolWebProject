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
        private ILogger markLogger;
        private IRepository<LessonDetail> repository;
        private IUnitOfWork unitOfWork;

        public LessonDetailService(ILogger logger, IRepository<LessonDetail> LessonDetailRepository, IUnitOfWork lessonDetailUnitOfWork)
            : base(logger)
        {
            this.markLogger = logger;
            this.repository = LessonDetailRepository;
            this.unitOfWork = lessonDetailUnitOfWork;
        }

        public IEnumerable<LessonDetail> GetAllLessonDetails()
        {
            return this.repository.GetAll();
        }

        public LessonDetail GetLessonDetailById(int id)
        {
            return this.repository.GetById(id);
        }

        public void UpdateLessonDetail(LessonDetail lessonDetail)
        {
            this.repository.Update(lessonDetail);
        }

        public void AddLessonDetail(LessonDetail lessonDetail)
        {
            this.repository.Add(lessonDetail);
        }

        public void RemoveLessonDetail(LessonDetail lessonDetail)
        {
            this.repository.Delete(lessonDetail);
        }

        public void SaveLessonDetail()
        {
            unitOfWork.SaveChanges();
        }
    }
}
