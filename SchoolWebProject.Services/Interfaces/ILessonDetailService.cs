using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services
{
    public interface ILessonDetailService
    {
        IEnumerable<LessonDetail> GetAllLessonDetails();

        void GenereteLessonDeatail(Schedule addedSchedule);

        LessonDetail GetLessonDetailById(int id);

        void UpdateLessonDetail(LessonDetail lessonDetail);

        void AddLessonDetail(LessonDetail lessonDetail);

        void RemoveLessonDetail(LessonDetail lessonDetail);
    }
}
