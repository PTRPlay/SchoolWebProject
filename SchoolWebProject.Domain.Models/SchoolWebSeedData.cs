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

             public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

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



    }
}
