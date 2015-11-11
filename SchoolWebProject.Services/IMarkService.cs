using SchoolWebProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface IMarkService
    {
        IEnumerable<Mark> GetAllMarks();

        Mark GetMarkById(int id);

        void UpdateMark(Mark mark);

        void AddMark(Mark mark);

        void RemoveMark(Mark mark);

        void SaveMark();
    }
}
