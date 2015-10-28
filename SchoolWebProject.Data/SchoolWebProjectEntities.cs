using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Data
{
    public class SchoolWebProjectEntities : DbContext
    {
        public SchoolWebProjectEntities() : base("SchoolWebProjectEntities") 
        { 
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
