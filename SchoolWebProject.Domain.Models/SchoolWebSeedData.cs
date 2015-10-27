using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    class SchoolWebSeedData : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            GetTeacherCategories().ForEach(c => context.TeacherCategories.Add(c));
            GetTeacherDegrees().ForEach(c => context.TeacherDegrees.Add(c));
            GetSchools().ForEach(c => context.Schools.Add(c));
   //         GetTeachers().ForEach(c => context.Users.Add(c));
            base.Seed(context);
        }

        private static List<TeacherCategory> GetTeacherCategories()
        {
            return new List<TeacherCategory>
            {
                new TeacherCategory {
                    Name = "cпеціаліст"
                },
                new TeacherCategory {
                    Name = "спеціаліст другої категорії"
                },
                new TeacherCategory {
                    Name = "спеціаліст першої категорії "
                },
                new TeacherCategory {
                    Name = "спеціаліст вищої категорії "
                }
            };
        }

        private static List<TeacherDegree> GetTeacherDegrees()
        {
            return new List<TeacherDegree>
            {
                new TeacherDegree {
                    Name = "викладач-методист"
                },
                new TeacherDegree {
                    Name = "учитель-методист"
                },
                new TeacherDegree {
                    Name = "вихователь-методист"
                },
                new TeacherDegree {
                    Name = "педагог-організатор-методист"
                },
                new TeacherDegree {
                    Name = "практичний психолог-методист"
                },
                new TeacherDegree {
                    Name = "керівник гуртка-методист"
                },
                new TeacherDegree {
                    Name = "старший викладач"
                },
                new TeacherDegree {
                    Name = "старший учитель"
                },
                               new TeacherDegree {
                    Name = "старший вихователь"
                },
                new TeacherDegree {
                    Name = "майстер виробничого навчання I категорії"
                },
                               new TeacherDegree {
                    Name = "майстер виробничого навчання II категорії"
                }
            };
        }

        private static List<School> GetSchools()
        {
            return new List<School>
            {
                new School {
                    Name = "Середня школа № 66",
                    City = "Львів",
                    Address = "Наукова, 92",
                    PhoneNumber = "+38 (032) 263-73-09"
                }
            };
        }


        private static List<Teacher> GetTeachers()
        {
            return new List<Teacher>
            {
                new Teacher {
                    FirstName = "Марія",
                    LastName = "Коваленко",   
                    MiddleName = "Денисівна",                    
                    PhoneNumber = "+38 (097) 767-73-09",
                    WorkBegin = new DateTime(2014, 6, 14),
                    TeacherCategoryId = 1,
                    TeacherDegreeId = 1,
                    RoleId = 1,
                    SchoolId=1,
                    LogInDataId=1,
                    OnlineId=1                    
                },

                   new Teacher {
                    FirstName = "Надія",
                    MiddleName = "Петрівна",
                    LastName = "Тимощук",                                           
                    PhoneNumber = "+38 (050) 265-00-09",
                    WorkBegin = new DateTime(2007, 5, 1),
                    TeacherCategoryId = 1,
                    TeacherDegreeId = 1,
                    RoleId = 1,
                    SchoolId=1,
                    LogInDataId=1,
                    OnlineId=1
                },
                
                    new Teacher {
                    FirstName = "Олена",
                    MiddleName = "Андріївна",
                    LastName = "Зелевська",                                           
                    PhoneNumber = "+38 (097) 677-73-09",
                    WorkBegin = new DateTime(2010, 1, 11),
                    TeacherCategoryId = 1,
                    TeacherDegreeId = 1,
                    RoleId = 1,
                    SchoolId=1,
                    LogInDataId=1,
                    OnlineId=1
                }
  
            };
        }






    }
}
