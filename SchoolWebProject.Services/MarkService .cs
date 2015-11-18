using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject;

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
            return unitOfWork.MarkRepository.GetAll();
        }

        public IEnumerable<Mark> GetMarksBySubjectAndGroup(int subjectId, int groupId)
        {
            var marks = unitOfWork.MarkRepository.GetAll()
                .Where(p => p.Pupil.GroupId == groupId);
            return marks;
        }

        public Mark GetMarkById(int id)
        {
            return unitOfWork.MarkRepository.GetById(id);
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
            unitOfWork.MarkRepository.Delete(mark);
        }

        public void SaveMark()
        {
            unitOfWork.SaveChanges();
        }
    }
}
