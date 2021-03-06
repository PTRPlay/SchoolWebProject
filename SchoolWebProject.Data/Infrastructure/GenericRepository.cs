﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Data.Infrastructure
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> dbSet;
        
        private SchoolContext dataContext;

        public GenericRepository(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            this.dbSet = this.DbContext.Set<T>();
        }

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected SchoolContext DbContext
        {
            get { return this.dataContext ?? (this.dataContext = this.DbFactory.Init()); }
        }

        public virtual void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Attach(T entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Unchanged;
            this.dbSet.Attach(entity);
        }

        public virtual void Update(T entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Modified;
            this.dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this.dbSet.Where<T>(where).AsEnumerable();

            foreach (T obj in objects)
            {
                this.dataContext.Entry(obj).State = EntityState.Modified;
                this.dbSet.Remove(obj);
            }
        }

        public virtual T GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return this.dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            try
            {
                return this.dbSet.Where(where).FirstOrDefault<T>();
            }
            catch
            {
                return null;
            }
        }
    }
}
