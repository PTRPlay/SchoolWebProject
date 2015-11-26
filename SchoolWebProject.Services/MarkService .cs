using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Services
{
    public class MarkService : BaseService, IMarkService
    {
        private ILogger tmpLogger;

        private UnitOfWork unitOfWork;

        public MarkService(ILogger logger, UnitOfWork unitOfWork)
            : base(logger)
        {
            this.tmpLogger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Mark> GetAllMarks()
        {
            return this.unitOfWork.MarkRepository.GetAll();
        }

        public IEnumerable<Mark> GetMarksBySubjectAndGroup(int subjectId, int groupId)
        {
            var marks = this.unitOfWork.MarkRepository.GetAll()
                .Where(p => p.Pupil.GroupId == groupId && p.LessonDetail.Schedule.SubjectId == subjectId)
                .OrderBy(s => s.Pupil.LastName)
                .OrderBy(s => s.LessonDetail.Date);
            return marks;
        }

        public Mark GetMarkById(int id)
        {
            return this.unitOfWork.MarkRepository.GetById(id);
        }

        public void UpdateMark(Mark mark)
        {
            this.unitOfWork.MarkRepository.Update(mark);
        }

        public void AddMark(Mark mark)
        {
            this.unitOfWork.MarkRepository.Add(mark);
        }

        public void RemoveMark(Mark mark)
        {
            this.unitOfWork.MarkRepository.Delete(mark);
        }

        public void SaveMark()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}
