using System;
using SchoolWebProject.Domain.Models;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Data.Configuration
{
    class LessonDetailConfiguration : EntityTypeConfiguration<LessonDetail>
    {
        public LessonDetailConfiguration()
        {
            this.ToTable("LessonDetail");
        }
    }
}
