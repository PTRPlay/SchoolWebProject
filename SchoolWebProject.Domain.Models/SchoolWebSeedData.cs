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
new Teacher { LastName = "Бойченко", FirstName = "Ярослава", MiddleName = "Станіславівна", WorkBegin = new DateTime(1998, 6, 21), PhoneNumber = "693984558", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Гарланова", FirstName = "Євгенія", MiddleName = "Сергіївна", WorkBegin = new DateTime(2008, 3, 18), PhoneNumber = "993385320", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Євенко", FirstName = "Вадим", MiddleName = "Олегович", WorkBegin = new DateTime(1990, 7, 18), PhoneNumber = "290849203", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Карасевич", FirstName = "Владислав", MiddleName = "Олександрович", WorkBegin = new DateTime(1996, 2, 5), PhoneNumber = "181890830", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Кліщук", FirstName = "Марія", MiddleName = "Дмитрівна", WorkBegin = new DateTime(1996, 9, 4), PhoneNumber = "915391281", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Коваль", FirstName = "Вікторія", MiddleName = "Олександрівна", WorkBegin = new DateTime(2005, 11, 26), PhoneNumber = "770638463", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Ковриняк", FirstName = "Аліна", MiddleName = "Ігорівна", WorkBegin = new DateTime(2002, 6, 11), PhoneNumber = "897890904", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Костенко", FirstName = "Катерина", MiddleName = "Андріївна", WorkBegin = new DateTime(1995, 8, 16), PhoneNumber = "870798438", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Кучук", FirstName = "Денис", MiddleName = "Олександрович", WorkBegin = new DateTime(2006, 10, 7), PhoneNumber = "568383492", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Магденко", FirstName = "Дмитро", MiddleName = "Сергійович", WorkBegin = new DateTime(2010, 3, 19), PhoneNumber = "510638487", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Маслянко", FirstName = "Євгенія", MiddleName = "Дмитрівна", WorkBegin = new DateTime(2011, 10, 15), PhoneNumber = "989221260", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Мерінгер", FirstName = "Софія", MiddleName = "Аттілівна", WorkBegin = new DateTime(2003, 4, 28), PhoneNumber = "589274327", RoleId = 2, SchoolId = 1, TeacherCategoryId = 3 },
new Teacher { LastName = "Миколайчук", FirstName = "Ігор", MiddleName = "Олегович", WorkBegin = new DateTime(2009, 4, 22), PhoneNumber = "815237812", RoleId = 2, SchoolId = 1, TeacherCategoryId = 3 },
new Teacher { LastName = "Молодільченко", FirstName = "Олександр", MiddleName = "Родіонович", WorkBegin = new DateTime(2003, 3, 22), PhoneNumber = "938620922", RoleId = 2, SchoolId = 1, TeacherCategoryId = 3 },
new Teacher { LastName = "Ничик", FirstName = "Марія", MiddleName = "Дмитрівна", WorkBegin = new DateTime(2004, 7, 19), PhoneNumber = "971063766", RoleId = 2, SchoolId = 1, TeacherCategoryId = 3 },
new Teacher { LastName = "Новік", FirstName = "Марія", MiddleName = "Русланівна", WorkBegin = new DateTime(2000, 7, 19), PhoneNumber = "649764208", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Онофріюк", FirstName = "Владислав", MiddleName = "Діамідович", WorkBegin = new DateTime(2000, 4, 27), PhoneNumber = "627524861", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Пархоменко", FirstName = "Ілля", MiddleName = "Олександрович", WorkBegin = new DateTime(2005, 11, 24), PhoneNumber = "501214584", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Пестовніков", FirstName = "Ілля", MiddleName = "Миколайович", WorkBegin = new DateTime(2010, 8, 22), PhoneNumber = "105631096", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Проценко", FirstName = "Артем", MiddleName = "Леонідович", WorkBegin = new DateTime(1998, 2, 9), PhoneNumber = "827235850", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Сушко", FirstName = "Марія", MiddleName = "Олександрівна", WorkBegin = new DateTime(2004, 5, 20), PhoneNumber = "617825080", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Хондока", FirstName = "Андрій", MiddleName = "Станіславович", WorkBegin = new DateTime(1997, 3, 26), PhoneNumber = "191342731", RoleId = 2, SchoolId = 1, TeacherCategoryId = 3 },
new Teacher { LastName = "Чорновол", FirstName = "Давид", MiddleName = "Олегович", WorkBegin = new DateTime(1990, 8, 12), PhoneNumber = "217691772", RoleId = 2, SchoolId = 1, TeacherCategoryId = 2 },
new Teacher { LastName = "Чумак", FirstName = "Софія", MiddleName = "Ігорівна", WorkBegin = new DateTime(2002, 5, 9), PhoneNumber = "493163305", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Шадуріна", FirstName = "Марія", MiddleName = "Сергіївна", WorkBegin = new DateTime(2004, 5, 22), PhoneNumber = "582202379", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Юрченко", FirstName = "Кіра", MiddleName = "Андріївна", WorkBegin = new DateTime(2012, 10, 24), PhoneNumber = "478015234", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },
new Teacher { LastName = "Яремчук", FirstName = "Валерія", MiddleName = "Сергіївна", WorkBegin = new DateTime(1997, 3, 3), PhoneNumber = "211372772", RoleId = 2, SchoolId = 1, TeacherCategoryId = 1 },

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
                new Pupil { LastName = "Бондаренко", FirstName = "Родіон", MiddleName = "Олександрович", PhoneNumber = "390001655", RoleId = 3, SchoolId = 1, GroupId = 14 },
new Pupil { LastName = "Буга", FirstName = "Владислав", MiddleName = "Андрійович", PhoneNumber = "934380269", RoleId = 3, SchoolId = 1, GroupId = 7 },
new Pupil { LastName = "Бузівська", FirstName = "Світлана", MiddleName = "Анатоліївна", PhoneNumber = "999176438", RoleId = 3, SchoolId = 1, GroupId = 9 },
new Pupil { LastName = "Вітвіцька", FirstName = "Софія", MiddleName = "Русланівна", PhoneNumber = "777900289", RoleId = 3, SchoolId = 1, GroupId = 4 },
new Pupil { LastName = "Вовк", FirstName = "Ульяна", MiddleName = "Василівна", PhoneNumber = "771914660", RoleId = 3, SchoolId = 1, GroupId = 7 },
new Pupil { LastName = "Волощук", FirstName = "Яна", MiddleName = "Станіславівна", PhoneNumber = "638632880", RoleId = 3, SchoolId = 1, GroupId = 2 },
new Pupil { LastName = "Герасименко", FirstName = "Микола", MiddleName = "Олегович", PhoneNumber = "938698249", RoleId = 3, SchoolId = 1, GroupId = 3 },
new Pupil { LastName = "Гримовськиий", FirstName = "Данило", MiddleName = "Владиславович", PhoneNumber = "211495136", RoleId = 3, SchoolId = 1, GroupId = 15 },
new Pupil { LastName = "Данько", FirstName = "Максим", MiddleName = "Олександрович", PhoneNumber = "619958232", RoleId = 3, SchoolId = 1, GroupId = 7 },
new Pupil { LastName = "Завінський", FirstName = "Павло", MiddleName = "Віталійович", PhoneNumber = "645819106", RoleId = 3, SchoolId = 1, GroupId = 1 },
new Pupil { LastName = "Заєць", FirstName = "Дмитро", MiddleName = "Станіславович", PhoneNumber = "164551471", RoleId = 3, SchoolId = 1, GroupId = 4 },
new Pupil { LastName = "Кожушко", FirstName = "Богдан", MiddleName = "Олександрович", PhoneNumber = "926367272", RoleId = 3, SchoolId = 1, GroupId = 1 },
new Pupil { LastName = "Колотуша", FirstName = "Максим", MiddleName = "Олександрович", PhoneNumber = "853886047", RoleId = 3, SchoolId = 1, GroupId = 11 },
new Pupil { LastName = "Красилівський", FirstName = "Петро", MiddleName = "Олександрович", PhoneNumber = "849234818", RoleId = 3, SchoolId = 1, GroupId = 1 },
new Pupil { LastName = "Крикунов", FirstName = "Владислав", MiddleName = "Валерійович", PhoneNumber = "825654271", RoleId = 3, SchoolId = 1, GroupId = 13 },
new Pupil { LastName = "Лосіцька", FirstName = "Наталія", MiddleName = "Едуардівна", PhoneNumber = "371166751", RoleId = 3, SchoolId = 1, GroupId = 10 },
new Pupil { LastName = "Луцюк", FirstName = "Іван", MiddleName = "Анатолійович", PhoneNumber = "610476231", RoleId = 3, SchoolId = 1, GroupId = 1 },
new Pupil { LastName = "Потьомкіна", FirstName = "Анастасія", MiddleName = "Віталіївна", PhoneNumber = "717460684", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Пелих", FirstName = "Дарина", MiddleName = "Володимирівна", PhoneNumber = "210573390", RoleId = 3, SchoolId = 1, GroupId = 13 },
new Pupil { LastName = "Свідерська", FirstName = "Яна", MiddleName = "Юріївна", PhoneNumber = "902011227", RoleId = 3, SchoolId = 1, GroupId = 11 },
new Pupil { LastName = "Сімборський", FirstName = "Андрій", MiddleName = "Ігорович", PhoneNumber = "608091974", RoleId = 3, SchoolId = 1, GroupId = 15 },
new Pupil { LastName = "Сіроштан", FirstName = "Владислав", MiddleName = "Миколайович", PhoneNumber = "291566595", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Слободяник", FirstName = "Софія", MiddleName = "Михайлівна", PhoneNumber = "338509165", RoleId = 3, SchoolId = 1, GroupId = 3 },
new Pupil { LastName = "Тарнавська", FirstName = "Анастасія", MiddleName = "Олегівна", PhoneNumber = "853508925", RoleId = 3, SchoolId = 1, GroupId = 6 },
new Pupil { LastName = "Топтун", FirstName = "Юлія", MiddleName = "Владиславівна", PhoneNumber = "416904765", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Фархутдінов", FirstName = "Дмитро", MiddleName = "Русланович", PhoneNumber = "958921711", RoleId = 3, SchoolId = 1, GroupId = 10 },
new Pupil { LastName = "Чижевська", FirstName = "Анастасія", MiddleName = "Василівна", PhoneNumber = "632047181", RoleId = 3, SchoolId = 1, GroupId = 2 },
new Pupil { LastName = "Чмига", FirstName = "Дмитро", MiddleName = "Юрійович", PhoneNumber = "656407973", RoleId = 3, SchoolId = 1, GroupId = 9 },
new Pupil { LastName = "Берегова", FirstName = "Юлія", MiddleName = "Петрівна", PhoneNumber = "274943712", RoleId = 3, SchoolId = 1, GroupId = 13 },
new Pupil { LastName = "Біленко", FirstName = "Володимир", MiddleName = "Миколайович", PhoneNumber = "971453963", RoleId = 3, SchoolId = 1, GroupId = 14 },
new Pupil { LastName = "Білий", FirstName = "Олександр", MiddleName = "Сергійович", PhoneNumber = "582358707", RoleId = 3, SchoolId = 1, GroupId = 6 },
new Pupil { LastName = "Будякова", FirstName = "Руслана", MiddleName = "Володимирівна", PhoneNumber = "161261128", RoleId = 3, SchoolId = 1, GroupId = 14 },
new Pupil { LastName = "Вертипорох", FirstName = "Владислав", MiddleName = "Станіславович", PhoneNumber = "627548757", RoleId = 3, SchoolId = 1, GroupId = 6 },
new Pupil { LastName = "Гоцик", FirstName = "Володимир", MiddleName = "Володимирович", PhoneNumber = "248399224", RoleId = 3, SchoolId = 1, GroupId = 5 },
new Pupil { LastName = "Головченко", FirstName = "Вікторія", MiddleName = "Валентинівна", PhoneNumber = "368224715", RoleId = 3, SchoolId = 1, GroupId = 11 },
new Pupil { LastName = "Гурбич", FirstName = "Микола", MiddleName = "Миколайович", PhoneNumber = "543909398", RoleId = 3, SchoolId = 1, GroupId = 15 },
new Pupil { LastName = "Ковилова", FirstName = "Ольга", MiddleName = "Віталіївна", PhoneNumber = "155197791", RoleId = 3, SchoolId = 1, GroupId = 9 },
new Pupil { LastName = "Комісаренко", FirstName = "Назар", MiddleName = "Анатолійович", PhoneNumber = "300705476", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Кокоулін", FirstName = "Микола", MiddleName = "Вікторович", PhoneNumber = "731647072", RoleId = 3, SchoolId = 1, GroupId = 15 },
new Pupil { LastName = "Кравчук", FirstName = "Яна", MiddleName = "Русланівна", PhoneNumber = "842142409", RoleId = 3, SchoolId = 1, GroupId = 12 },
new Pupil { LastName = "Крижанівська", FirstName = "Анна", MiddleName = "Миколаївна", PhoneNumber = "697877938", RoleId = 3, SchoolId = 1, GroupId = 4 },
new Pupil { LastName = "Лозан", FirstName = "Віталій", MiddleName = "Володимирович", PhoneNumber = "863187086", RoleId = 3, SchoolId = 1, GroupId = 9 },
new Pupil { LastName = "Макодзеба", FirstName = "Вікторія", MiddleName = "Богданівна", PhoneNumber = "201685677", RoleId = 3, SchoolId = 1, GroupId = 15 },
new Pupil { LastName = "Маленко", FirstName = "Мирослава", MiddleName = "Вікторівна", PhoneNumber = "131500921", RoleId = 3, SchoolId = 1, GroupId = 13 },
new Pupil { LastName = "Ніженський", FirstName = "Роман", MiddleName = "Анатолійович", PhoneNumber = "719743434", RoleId = 3, SchoolId = 1, GroupId = 2 },
new Pupil { LastName = "Павленко", FirstName = "Володимир", MiddleName = "Влодимирович", PhoneNumber = "418300888", RoleId = 3, SchoolId = 1, GroupId = 2 },
new Pupil { LastName = "Поліщук", FirstName = "Юрій", MiddleName = "Юрійович", PhoneNumber = "757393337", RoleId = 3, SchoolId = 1, GroupId = 6 },
new Pupil { LastName = "Сивокінь", FirstName = "Ростислав", MiddleName = "Олегович", PhoneNumber = "830910911", RoleId = 3, SchoolId = 1, GroupId = 3 },
new Pupil { LastName = "Тимченко", FirstName = "Катерина", MiddleName = "Вадимівна", PhoneNumber = "668950162", RoleId = 3, SchoolId = 1, GroupId = 11 },
new Pupil { LastName = "Тітаренко", FirstName = "Наталія", MiddleName = "Ігорівна", PhoneNumber = "771218439", RoleId = 3, SchoolId = 1, GroupId = 11 },
new Pupil { LastName = "Тертична", FirstName = "Альона", MiddleName = "Леонідівна", PhoneNumber = "995164351", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Хуторовий", FirstName = "Іван", MiddleName = "Тарасович", PhoneNumber = "630677197", RoleId = 3, SchoolId = 1, GroupId = 7 },
new Pupil { LastName = "Чернуха", FirstName = "Лілія", MiddleName = "Романівна", PhoneNumber = "796736589", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Швець", FirstName = "Аліна", MiddleName = "Романівна", PhoneNumber = "799704462", RoleId = 3, SchoolId = 1, GroupId = 11 },
new Pupil { LastName = "Шинкаренко", FirstName = "Андрій", MiddleName = "Олегович", PhoneNumber = "864280644", RoleId = 3, SchoolId = 1, GroupId = 7 },
new Pupil { LastName = "Шкода", FirstName = "Дмитро", MiddleName = "Олегович", PhoneNumber = "966415172", RoleId = 3, SchoolId = 1, GroupId = 5 },
new Pupil { LastName = "Даниленко", FirstName = "Владислав", MiddleName = "Вікторович", PhoneNumber = "670787750", RoleId = 3, SchoolId = 1, GroupId = 14 },
new Pupil { LastName = "Завірюха", FirstName = "Ярослава", MiddleName = "Валентинівна", PhoneNumber = "316413557", RoleId = 3, SchoolId = 1, GroupId = 2 },
new Pupil { LastName = "Іващенко", FirstName = "Дарина", MiddleName = "Андріївна", PhoneNumber = "424518928", RoleId = 3, SchoolId = 1, GroupId = 3 },
new Pupil { LastName = "Клименко", FirstName = "Назарій", MiddleName = "Андрійович", PhoneNumber = "215327611", RoleId = 3, SchoolId = 1, GroupId = 6 },
new Pupil { LastName = "Косарєва", FirstName = "Ірина", MiddleName = "Віталіївна", PhoneNumber = "157905756", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Кравчук", FirstName = "Анна", MiddleName = "Олегівна", PhoneNumber = "598821087", RoleId = 3, SchoolId = 1, GroupId = 10 },
new Pupil { LastName = "Лелека", FirstName = "Юлія", MiddleName = "Вячеславівна", PhoneNumber = "372831273", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Маленко", FirstName = "Наталія", MiddleName = "Андріївна", PhoneNumber = "913846729", RoleId = 3, SchoolId = 1, GroupId = 5 },
new Pupil { LastName = "Пелехатий", FirstName = "Сергій", MiddleName = "Олегович", PhoneNumber = "717277351", RoleId = 3, SchoolId = 1, GroupId = 14 },
new Pupil { LastName = "Приходько", FirstName = "Мирослава", MiddleName = "Олегівна", PhoneNumber = "727339843", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Проценко", FirstName = "Валентина", MiddleName = "Віталіївна", PhoneNumber = "624906221", RoleId = 3, SchoolId = 1, GroupId = 9 },
new Pupil { LastName = "Соколовський", FirstName = "Дмитро", MiddleName = "Олександрович", PhoneNumber = "191119101", RoleId = 3, SchoolId = 1, GroupId = 2 },
new Pupil { LastName = "Ставянко", FirstName = "Володимир", MiddleName = "Володимирович", PhoneNumber = "643714332", RoleId = 3, SchoolId = 1, GroupId = 8 },
new Pupil { LastName = "Щербак", FirstName = "Юлія", MiddleName = "Миколаївна", PhoneNumber = "852598528", RoleId = 3, SchoolId = 1, GroupId = 3 },
new Pupil { LastName = "Яровий", FirstName = "Ростислав", MiddleName = "Тарасович", PhoneNumber = "849923466", RoleId = 3, SchoolId = 1, GroupId = 1 },
new Pupil { LastName = "Андріянова", FirstName = "Валерія", MiddleName = "Олександрівна", PhoneNumber = "221545656", RoleId = 3, SchoolId = 1, GroupId = 12 },
new Pupil { LastName = "Безталанний", FirstName = "Валерій", MiddleName = "Ігорович", PhoneNumber = "174981066", RoleId = 3, SchoolId = 1, GroupId = 3 },
new Pupil { LastName = "Бойко", FirstName = "Галина", MiddleName = "Сергіївна", PhoneNumber = "747324489", RoleId = 3, SchoolId = 1, GroupId = 4 },
new Pupil { LastName = "Бойко", FirstName = "Наталія", MiddleName = "Миколаївна", PhoneNumber = "826078590", RoleId = 3, SchoolId = 1, GroupId = 15 },
new Pupil { LastName = "Доманіцька", FirstName = "Мирослава", MiddleName = "Олегівна", PhoneNumber = "244797703", RoleId = 3, SchoolId = 1, GroupId = 3 },
new Pupil { LastName = "Заїченко", FirstName = "Владислав", MiddleName = "Юрійович", PhoneNumber = "561038227", RoleId = 3, SchoolId = 1, GroupId = 15 },
new Pupil { LastName = "Ільчук", FirstName = "Анна", MiddleName = "Володимирівна", PhoneNumber = "622825742", RoleId = 3, SchoolId = 1, GroupId = 10 },
new Pupil { LastName = "Кисельов", FirstName = "Владислав", MiddleName = "Сергійович", PhoneNumber = "423368353", RoleId = 3, SchoolId = 1, GroupId = 6 },
new Pupil { LastName = "Коноваленко", FirstName = "Юлія", MiddleName = "Олегівна", PhoneNumber = "507426910", RoleId = 3, SchoolId = 1, GroupId = 11 },
new Pupil { LastName = "Кравченко", FirstName = "Олександр", MiddleName = "Володимирович", PhoneNumber = "652452782", RoleId = 3, SchoolId = 1, GroupId = 12 },
new Pupil { LastName = "Лубневський", FirstName = "Денис", MiddleName = "Юрійович", PhoneNumber = "883452512", RoleId = 3, SchoolId = 1, GroupId = 1 },
new Pupil { LastName = "Мочалко", FirstName = "Жанна", MiddleName = "Миколаївна", PhoneNumber = "970077905", RoleId = 3, SchoolId = 1, GroupId = 10 },
new Pupil { LastName = "Пантелей", FirstName = "Анна", MiddleName = "Олександрівна", PhoneNumber = "231351193", RoleId = 3, SchoolId = 1, GroupId = 10 },
new Pupil { LastName = "Сніцаренко", FirstName = "Владислав", MiddleName = "Олександрович", PhoneNumber = "201981946", RoleId = 3, SchoolId = 1, GroupId = 9 },
new Pupil { LastName = "Черепенко", FirstName = "Оксана", MiddleName = "Сергіївна", PhoneNumber = "495037411", RoleId = 3, SchoolId = 1, GroupId = 14 },
new Pupil { LastName = "Щепак", FirstName = "Олександр", MiddleName = "Петрович", PhoneNumber = "504355778", RoleId = 3, SchoolId = 1, GroupId = 15 },
new Pupil { LastName = "Яцина", FirstName = "Наталія", MiddleName = "Анатоліївна", PhoneNumber = "744939163", RoleId = 3, SchoolId = 1, GroupId = 14 },

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
                new ClassRoom { SchoolId = 1, Name = "каб.№ 11" },
                new ClassRoom { SchoolId = 1, Name = "каб.№ 12" },
                new ClassRoom { SchoolId = 1, Name = "каб.№ 15" },
                new ClassRoom { SchoolId = 1, Name = "каб.№ 16" },
                new ClassRoom { SchoolId = 1, Name = "каб.№ 27" },
                new ClassRoom { SchoolId = 1, Name = "каб.№ 28" },
                new ClassRoom { SchoolId = 1, Name = "спортзал №1" },
                new ClassRoom { SchoolId = 1, Name = "спортзал №2" },
                new ClassRoom { SchoolId = 1, Name = "актовий зал" },
            };
        }
    }
}
