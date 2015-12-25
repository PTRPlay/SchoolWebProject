using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        #region Repositories
        IRepository<Announcement> AnnouncementRepository { get; }

        IRepository<Group> GroupRepository { get; }

        IRepository<Holidays> HolidaysRepository { get; }

        IRepository<LessonDetail> LessonDetailRepository { get; }

        IRepository<LogInData> LogInDataRepository { get; }

        IRepository<Mark> MarkRepository { get; }

        IRepository<MarkType> MarkTypeRepository { get; }

        IRepository<Teacher> TeacherRepository { get; }

        IRepository<TeacherCategory> TeacherCategoryRepository { get; }

        IRepository<TeacherDegree> TeacherDegreeRepository { get; }
        
        IRepository<Pupil> PupilRepository { get; }

        IRepository<Schedule> ScheduleRepository { get; }

        IRepository<School> SchoolRepository { get; }
        
        IRepository<Subject> SubjectRepository { get; }

        IRepository<User> UserRepository { get; }

        IRepository<Role> RoleRepository { get; }

        IRepository<Parent> ParentRepository { get; }

        IRepository<ClassRoom> ClassRoomRepository { get; }
        #endregion 

        void SaveChanges();
    }
}
