﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace MS.Data.Repositories.Abstraction
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);
    }
}
