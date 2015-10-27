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
    }
}
