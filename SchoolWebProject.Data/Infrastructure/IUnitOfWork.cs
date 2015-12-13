﻿using System;
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
        GenericRepository<Announcement> AnnouncementRepository { get; }

        GenericRepository<Group> GroupRepository { get; }

        GenericRepository<Holidays> HolidaysRepository { get; }

        GenericRepository<LessonDetail> LessonDetailRepository { get; }

        GenericRepository<LogInData> LogInDataRepository { get; }

        GenericRepository<Mark> MarkRepository { get; }

        GenericRepository<MarkType> MarkTypeRepository { get; }

        IRepository<Teacher> TeacherRepository { get; }

        GenericRepository<TeacherCategory> TeacherCategoryRepository { get; }

        GenericRepository<TeacherDegree> TeacherDegreeRepository { get; }
        
        GenericRepository<Pupil> PupilRepository { get; }

        GenericRepository<Schedule> ScheduleRepository { get; }

        GenericRepository<School> SchoolRepository { get; }
        
        IRepository<Subject> SubjectRepository { get; }

        GenericRepository<User> UserRepository { get; }

        GenericRepository<Role> RoleRepository { get; }

        GenericRepository<Parent> ParentRepository { get; }

        GenericRepository<ClassRoom> ClassRoomRepository { get; }
        #endregion 

        void SaveChanges();
    }
}
