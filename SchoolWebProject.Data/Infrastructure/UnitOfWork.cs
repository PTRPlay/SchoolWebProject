using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory dbFactory;

        private SchoolContext dbContext;

        #region Definition of repositories

        private GenericRepository<Announcement> announcementRepository;

        private GenericRepository<Group> groupRepository;

        private GenericRepository<Holidays> holidaysRepository;

        private GenericRepository<LessonDetail> lessonDetailRepository;

        private GenericRepository<LogInData> loginDataRepository;

        private GenericRepository<Mark> markRepository;

        private GenericRepository<MarkType> markTypeRepository;

        private GenericRepository<Pupil> pupilRepository;

        private GenericRepository<Schedule> scheduleRepository;

        private GenericRepository<School> schoolRepository;

        private GenericRepository<Subject> subjectRepository;

        private GenericRepository<Teacher> teacherRepository;

        private GenericRepository<TeacherCategory> teacherCategoryRepository;

        private GenericRepository<TeacherDegree> teacherDegreeRepository;

        private GenericRepository<User> userRepository;

        private GenericRepository<Role> roleRepository;

        private GenericRepository<Parent> parentRepository; 
        #endregion 

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        #region Init Repositories

        public GenericRepository<Announcement> AnnouncementRepository
        {
            get
            {
                if (this.announcementRepository == null)
                {
                    this.announcementRepository = new GenericRepository<Announcement>(this.dbFactory);
                }
                
                return this.announcementRepository;
            }
        }

        public GenericRepository<Group> GroupRepository
        {
            get
            {
                if (this.groupRepository == null)
                {
                    this.groupRepository = new GenericRepository<Group>(this.dbFactory);
                }

                return this.groupRepository;
            }
        }

        public GenericRepository<Holidays> HolidaysRepository
        {
            get
            {
                if (this.holidaysRepository == null)
                {
                    this.holidaysRepository = new GenericRepository<Holidays>(this.dbFactory);
                }

                return this.holidaysRepository;
            }
        }

        public GenericRepository<LessonDetail> LessonDetailRepository
        {
            get
            {
                if (this.lessonDetailRepository == null)
                {
                    this.lessonDetailRepository = new GenericRepository<LessonDetail>(this.dbFactory);
                }

                return this.lessonDetailRepository;
            }
        }

        public GenericRepository<LogInData> LogInDataRepository
        {
            get
            {
                if (this.loginDataRepository == null)
                {
                    this.loginDataRepository = new GenericRepository<LogInData>(this.dbFactory);
                }

                return this.loginDataRepository;
            }
        }

        public GenericRepository<Mark> MarkRepository
        {
            get
            {
                if (this.markRepository == null)
                {
                    this.markRepository = new GenericRepository<Mark>(this.dbFactory);
                }

                return this.markRepository;
            }
        }

        public GenericRepository<MarkType> MarkTypeRepository
        {
            get
            {
                if (this.markTypeRepository == null)
                {
                    this.markTypeRepository = new GenericRepository<MarkType>(this.dbFactory);
                }

                return this.markTypeRepository;
            }
        }

        public GenericRepository<Pupil> PupilRepository
        {
            get
            {
                if (this.pupilRepository == null)
                {
                    this.pupilRepository = new GenericRepository<Pupil>(this.dbFactory);
                }

                return this.pupilRepository;
            }
        }

        public GenericRepository<Schedule> ScheduleRepository
        {
            get
            {
                if (this.scheduleRepository == null)
                {
                    this.scheduleRepository = new GenericRepository<Schedule>(this.dbFactory);
                }

                return this.scheduleRepository;
            }
        }

        public GenericRepository<School> SchoolRepository
        {
            get
            {
                if (this.schoolRepository == null)
                {
                    this.schoolRepository = new GenericRepository<School>(this.dbFactory);
                }

                return this.schoolRepository;
            }
        }

        public GenericRepository<Subject> SubjectRepository
        {
            get
            {
                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new GenericRepository<Subject>(this.dbFactory);
                }

                return this.subjectRepository;
            }
        }

        public IRepository<Teacher> TeacherRepository
        {
            get
            {
                if (this.teacherRepository == null)
                {
                    this.teacherRepository = new GenericRepository<Teacher>(this.dbFactory);
                }

                return this.teacherRepository;
            }
        }

        public GenericRepository<TeacherCategory> TeacherCategoryRepository
        {
            get
            {
                if (this.teacherCategoryRepository == null)
                {
                    this.teacherCategoryRepository = new GenericRepository<TeacherCategory>(this.dbFactory);
                }

                return this.teacherCategoryRepository;
            }
        }

        public GenericRepository<TeacherDegree> TeacherDegreeRepository
        {
            get
            {
                if (this.teacherDegreeRepository == null)
                {
                    this.teacherDegreeRepository = new GenericRepository<TeacherDegree>(this.dbFactory);
                }

                return this.teacherDegreeRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(this.dbFactory);
                }

                return this.userRepository;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(this.dbFactory);
                }

                return this.roleRepository;
            }
        }

        public GenericRepository<Parent> ParentRepository
        {
            get
            {
                if (this.parentRepository == null)
                {
                    this.parentRepository = new GenericRepository<Parent>(this.dbFactory);
                }

                return parentRepository;
            }
        }

        #endregion

        public SchoolContext DbContext
        {
            get { return this.dbContext ?? (this.dbContext = this.dbFactory.Init()); }
        }

        public void SaveChanges()
        {
            this.DbContext.SaveChanges();
        }
    }
}
