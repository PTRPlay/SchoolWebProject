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

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

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
