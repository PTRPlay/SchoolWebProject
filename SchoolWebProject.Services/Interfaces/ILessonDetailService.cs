using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public interface ILessonDetailService
    {
        IEnumerable<ViewLessonDetail> GetAllLessonDetails();

        void GenereteLessonDeatail(Schedule addedSchedule);

        ViewLessonDetail GetLessonDetailById(int id);

        void UpdateLessonDetail(LessonDetail lessonDetail);

        void AddLessonDetail(ViewLessonDetail lessonDetail);
    }
}
