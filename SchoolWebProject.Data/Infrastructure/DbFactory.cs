using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SchoolContext dbContext;

        public SchoolContext Init()
        { 
            return this.dbContext ?? (this.dbContext = new SchoolContext());
        }

        protected override void DisposeCore()
        {
            if (this.dbContext != null)
            {
                this.dbContext.Dispose();
            }
        }
    }
}
