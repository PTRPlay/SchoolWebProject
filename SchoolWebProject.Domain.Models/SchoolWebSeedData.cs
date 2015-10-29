using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class SchoolWebSeedData : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            GetRoles().ForEach(c => context.Roles.Add(c));
            GetTeacherCategories().ForEach(c => context.TeacherCategories.Add(c));
            GetTeacherDegrees().ForEach(c => context.TeacherDegrees.Add(c));
            GetSubjects().ForEach(c => context.Subjects.Add(c));
            GetSchools().ForEach(c => context.Schools.Add(c));
            context.SaveChanges();
            GetAnnouncements().ForEach(c => context.Announcements.Add(c));
            GetClassRooms().ForEach(c => context.ClassRooms.Add(c));
            GetTeachers().ForEach(c => context.Users.Add(c));
            GetGroups().ForEach(c => context.Groups.Add(c));
            GetPupils().ForEach(c => context.Users.Add(c));
            base.Seed(context);
        }

        private static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role { Name = "admin" },
                new Role { Name = "teacher" },
                new Role { Name = "pupil" },
                new Role { Name = "parent" }
            };
        }

        private static List<TeacherCategory> GetTeacherCategories()
        {
            return new List<TeacherCategory>
            {
                new TeacherCategory { Name = "cпеціаліст" },
                new TeacherCategory { Name = "спеціаліст другої категорії" },
                new TeacherCategory { Name = "спеціаліст першої категорії" },
                new TeacherCategory { Name = "спеціаліст вищої категорії" }
            };
        }

        private static List<TeacherDegree> GetTeacherDegrees()
        {
            return new List<TeacherDegree>
            {
                new TeacherDegree { Name = "викладач-методист" },
                new TeacherDegree { Name = "учитель-методист" },
                new TeacherDegree { Name = "вихователь-методист" },
                new TeacherDegree { Name = "педагог-організатор-методист" },
                new TeacherDegree { Name = "практичний психолог-методист" },
                new TeacherDegree { Name = "керівник гуртка-методист" },
                new TeacherDegree { Name = "старший викладач" },
                new TeacherDegree { Name = "старший учитель" },
                new TeacherDegree { Name = "старший вихователь" },
                new TeacherDegree { Name = "майстер виробничого навчання I категорії" },
                new TeacherDegree { Name = "майстер виробничого навчання II категорії" }
            };
        }

        private static List<Subject> GetSubjects()
        {
            return new List<Subject>
            {
                new Subject { Name = "хімія" },
                new Subject { Name = "фізика" },
                new Subject { Name = "математика" },
                new Subject { Name = "історія" },
                new Subject { Name = "українська мова" },
                new Subject { Name = "англійська мова" },
                new Subject { Name = "географія" },
                new Subject { Name = "алгебра" },
                new Subject { Name = "геометрія" },
                new Subject { Name = "правознавство" },
                new Subject { Name = "українська література" },
                new Subject { Name = "біологія" }
            };
        }

        private static List<School> GetSchools()
        {
            return new List<School>
            {
                new School 
                {
                    Name = "Середня школа № 66",
                    City = "Львів",
                    Address = "Наукова, 92",
                    PhoneNumber = "+38 (032) 263-73-09"
                },
                new School 
                {
                    Name = "Середня школа № 46",
                    City = "Львів",
                    Address = "Наукова",
                    PhoneNumber = "+38 (032) 265-89-09"
                },
                 new School 
                 {
                    Name = "Гімназія ім. В.Симоненка",
                    City = "Львів",
                    Address = "Наукова",
                    PhoneNumber = "+38 (032) 243-73-59"
                }
            };
        }

        private static List<Group> GetGroups()
        {
            return new List<Group>
            {
                new Group { NameNumber = 1, NameLetter = "А", SchoolId = 1 },
                new Group { NameNumber = 1, NameLetter = "Б", SchoolId = 1 },
                new Group { NameNumber = 1, NameLetter = "В", SchoolId = 1 },
                new Group { NameNumber = 2, NameLetter = "А", SchoolId = 1 },
                new Group { NameNumber = 2, NameLetter = "Б", SchoolId = 1 },
                new Group { NameNumber = 3, NameLetter = "А", SchoolId = 1 },
                new Group { NameNumber = 5, NameLetter = "А", SchoolId = 1 },
                new Group { NameNumber = 5, NameLetter = "Б", SchoolId = 1 },
                new Group { NameNumber = 5, NameLetter = "В", SchoolId = 1 },
                new Group { NameNumber = 7, NameLetter = "А", SchoolId = 1 },
                new Group { NameNumber = 7, NameLetter = "Б", SchoolId = 1 },
                new Group { NameNumber = 10, NameLetter = "А", SchoolId = 1 },
                new Group { NameNumber = 10, NameLetter = "Б", SchoolId = 1 },
                new Group { NameNumber = 11, NameLetter = "А", SchoolId = 1 },
                new Group { NameNumber = 11, NameLetter = "Б", SchoolId = 1 },
                new Group { NameNumber = 11, NameLetter = "В", SchoolId = 1 }
            };
        }

       private static List<Teacher> GetTeachers()
        {
            return new List<Teacher>
            {
                new Teacher 
                {
                    FirstName = "Марія",
                    LastName = "Коваленко",   
                    MiddleName = "Денисівна",                    
                    PhoneNumber = "+38 (097) 767-73-09",
                    WorkBegin = new DateTime(2014, 6, 14),
                    TeacherCategoryId = 1,
                    TeacherDegreeId = 1,
                    RoleId = 2,
                    SchoolId = 1
              ////      LogInDataId = 1,
              ////      OnlineId = 1                    
                },

                   new Teacher 
                   {
                    FirstName = "Надія",
                    MiddleName = "Петрівна",
                    LastName = "Тимощук",                                           
                    PhoneNumber = "+38 (050) 265-00-09",
                    WorkBegin = new DateTime(2007, 5, 1),
                    TeacherCategoryId = 1,
                    TeacherDegreeId = 5,
                    RoleId = 2,
                    SchoolId = 1
              ////      LogInDataId = 1,
              ////      OnlineId = 1
                },
                
                    new Teacher
                    {
                    FirstName = "Олена",
                    MiddleName = "Андріївна",
                    LastName = "Зелевська",                                           
                    PhoneNumber = "+38 (097) 677-73-09",
                    WorkBegin = new DateTime(2010, 1, 11),
                    TeacherCategoryId = 3,
                    TeacherDegreeId = 1,
                    RoleId = 2,
                    SchoolId = 1
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                }
            };
        }

       private static List<Pupil> GetPupils()
       {
           return new List<Pupil>
            {
                new Pupil 
                {
                    FirstName = "Семен",
                    LastName = "Коваленко",   
                    MiddleName = "Петрович",                    
                    PhoneNumber = "+38 (097) 767-73-09",
                    RoleId = 3,
                    SchoolId = 1,
                    GroupId = 3
              ////      LogInDataId = 1,
              ////      OnlineId = 1                    
                },

                   new Pupil 
                   {
                    FirstName = "Ірина",
                    MiddleName = "Петрівна",
                    LastName = "Щеботова",                                           
                    PhoneNumber = "+38 (050) 265-00-09",
                    RoleId = 3,
                    SchoolId = 1,
                    GroupId = 3
              ////      LogInDataId = 1,
              ////      OnlineId = 1
                },
                
                    new Pupil
                    {
                    FirstName = "Микола",
                    MiddleName = "Андріїович",
                    LastName = "Ковалов",                                           
                    PhoneNumber = "+38 (097) 677-73-09",
                    RoleId = 3,
                    SchoolId = 1,
                    GroupId = 3
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                },
                     new Pupil
                    {
                    FirstName = "Назар", MiddleName = "Андріїович", LastName = "Гаврилів",                                           
                    PhoneNumber = "+38 (097) 677-73-09",
                    RoleId = 3, SchoolId = 1, GroupId = 9
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                },
                     new Pupil
                    {
                    FirstName = "Микола", MiddleName = "Назарович", LastName = "Максимчук",                                           
                    PhoneNumber = "+38 (097) 117-73-09",
                    RoleId = 3, SchoolId = 1, GroupId = 9
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                },
                     new Pupil
                    {
                    FirstName = "Олег", MiddleName = "Олексійович", LastName = "Денисік",                                           
                    PhoneNumber = "+38 (097) 547-73-09",
                    RoleId = 3, SchoolId = 1, GroupId = 5
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                },
                     new Pupil
                    {
                    FirstName = "Данило", MiddleName = "Вікторович", LastName = "Лавринович",                                           
                    PhoneNumber = "+38 (097) 907-73-09",
                    RoleId = 3, SchoolId = 1, GroupId = 9 
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                },
                     new Pupil
                    {
                    FirstName = "Тарас", MiddleName = "Семенович", LastName = "Марков",                                           
                    PhoneNumber = "+38 (097) 177-73-66",
                    RoleId = 3, SchoolId = 1, GroupId = 9
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                },
                    new Pupil
                    {
                    FirstName = "Софія", MiddleName = "Денисівна", LastName = "Моцак",                                           
                    PhoneNumber = "+38 (097) 547-73-09",
                    RoleId = 3, SchoolId = 1, GroupId = 9
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                },
                     new Pupil
                    {
                    FirstName = "Олександра", MiddleName = "Вікторівнач", LastName = "Грибавська",                                           
                    PhoneNumber = "+38 (097) 907-73-09",
                    RoleId = 3, SchoolId = 1, GroupId = 5 
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                },
                     new Pupil
                    {
                    FirstName = "Наталя", MiddleName = "Семенівна", LastName = "Маркова",                                           
                    PhoneNumber = "+38 (097) 177-73-66",
                    RoleId = 3, SchoolId = 1, GroupId = 5
                ////    LogInDataId = 1,
                ////    OnlineId = 1
                }
            };
           
       }

        private static List<Announcement> GetAnnouncements()
        {
            return new List<Announcement>
            {
                new Announcement
                {
                    Title = "І етап адаптаційних занять для майбутніх першокласників",
                    Message = "Оголошуємо набір учнів у 1-ий клас на 2016-2017 н.р.",
                    MessageDetails = "АДАПТАЦІЙНІ ЗАНЯТТЯ ПРОВОДЯТЬСЯ І етап – з 01.10.15 р. кожного вівторка та четверга о 16 год. 00 хв.",
                    DataPublished = new DateTime(2010, 1, 11),
                ////  Image = null,
               ////   UserId =  1,
                    SchoolId = 1
                },
                 new Announcement
                {
                    Title = "День учнівського самоврядування",
                    Message = "Роль учнівського самоврядування набуває значення",
                    MessageDetails = "Безперечно, навички управління суспільством стануть надбанням",
                    DataPublished = new DateTime(2010, 6, 11),
                ////  Image = null,
               ////   UserId =  1,
                    SchoolId = 1
                },
                 new Announcement
                {
                    Title = "Загальношкільна конференція",
                    Message = "Сьогодні відбулась загальношкільна конференція учнів.   ",
                    MessageDetails = "План конференції: 1. Обрання голови конференції.  ",
                    DataPublished = new DateTime(2010, 11, 9),
                ////  Image = null,
               ////   UserId =  1,
                    SchoolId = 1
                }
            };
        }
 
        private static List<ClassRoom> GetClassRooms()
        {
            return new List<ClassRoom>
            {
                new ClassRoom{
                    SchoolId = 1,
                    Name = "каб.№ 11"
                },
                new ClassRoom{
                    SchoolId = 1,
                    Name = "каб.№ 12"
                },
                new ClassRoom{
                    SchoolId = 1,
                    Name = "каб.№ 15"
                },
                new ClassRoom{
                    SchoolId = 1,
                    Name = "каб.№ 16"
                },
                new ClassRoom{
                    SchoolId = 1,
                    Name = "каб.№ 27"
                },
                new ClassRoom{
                    SchoolId = 1,
                    Name = "каб.№ 28"
                },
                new ClassRoom{
                    SchoolId = 1,
                    Name = "спортзал №1"
                },
                new ClassRoom{
                    SchoolId = 1,
                    Name = "спортзал №2"
                },
                new ClassRoom{
                    SchoolId = 1,
                    Name = "актовий зал"
                },
            };
        }
    }
}
