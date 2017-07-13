﻿using MS.Data.Abstraction;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MS.Data.Repositories.Abstraction
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(IMovieSystemDbContext context)
        {
            this.Context = context;
            this.Set = context.Set<T>();
        }

        protected IMovieSystemDbContext Context { get; set; }

        protected IDbSet<T> Set { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.Set.AsQueryable();
        }

        public virtual void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set.Attach(entity);
            }

            entry.State = EntityState.Added;
        }

        public virtual void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set.Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.All().Where(predicate);
        }

        public void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}
