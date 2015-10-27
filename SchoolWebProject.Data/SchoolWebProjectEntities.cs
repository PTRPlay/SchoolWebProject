using System;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Data;
using SchoolWebProject.Data.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Data
{
    public class SchoolWebProjectEntities : DbContext
    {
        public SchoolWebProjectEntities() : base("SchoolWebProjectEntities") { }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Holidays> Holidayss { get; set; }
        public DbSet<LessonDetail> LessonDetails { get; set; }
        public DbSet<LogInData> LogInDatas { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarkType> MarkTypes { get; set; }
        public DbSet<Online> Onlines { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SchoolContext> SchoolContexts { get; set; }
        public DbSet<SearchWord> SearchWords { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCategory> TeacherCategorys { get; set; }
        public DbSet<TeacherDegree> TeacherDegrees { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnnouncementConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new ClassRoomConfiguration());
            modelBuilder.Configurations.Add(new HolidaysConfiguration());
            modelBuilder.Configurations.Add(new LessonDetailConfiguration());
            modelBuilder.Configurations.Add(new LogInDataConfiguration());
            modelBuilder.Configurations.Add(new MarkConfiguration());
            modelBuilder.Configurations.Add(new MarkTypeConfiguration());
            modelBuilder.Configurations.Add(new OnlineConfiguration());
            modelBuilder.Configurations.Add(new ParentConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new PupilConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ScheduleConfiguration());
            modelBuilder.Configurations.Add(new SchoolConfiguration());
            modelBuilder.Configurations.Add(new SchoolContextConfiguration());
            modelBuilder.Configurations.Add(new SearchWordConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            modelBuilder.Configurations.Add(new TeacherCategoryConfiguration());
            modelBuilder.Configurations.Add(new TeacherDegreeConfiguration());
            modelBuilder.Configurations.Add(new TopicConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

        }
    }
}
