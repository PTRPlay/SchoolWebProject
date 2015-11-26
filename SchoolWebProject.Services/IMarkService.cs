using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services
{
    public interface IMarkService
    {
        IEnumerable<Mark> GetAllMarks();

        IEnumerable<Mark> GetMarksBySubjectAndGroup(int subjectId, int groupId);

        Mark GetMarkById(int id);

        void UpdateMark(Mark mark);

        void AddMark(Mark mark);

        void RemoveMark(Mark mark);

        void SaveMark();
    }
}
