using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class SchoolContext : DbContext 
    {
        private const string ConnectionStringSQLServer = "name=DbConnectionString";
        private const string ConnectionStringLocalDB = "WebSchoolDB";


        public SchoolContext()
            : base(ConnectionStringLocalDB)
        {
            Database.SetInitializer<SchoolContext>(new SchoolWebSeedData());
        }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Holidays> Holidays { get; set; }

        public DbSet<LogInData> LogInData { get; set; }

        public DbSet<Online> Online { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<SearchWord> SearchWords { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<TeacherCategory> TeacherCategories { get; set; }

        public DbSet<TeacherDegree> TeacherDegrees { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<MarkType> MarkTypes { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<LessonDetail> LessonDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
