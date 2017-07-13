using MS.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MS.Data.Abstraction
{
    public interface IMovieSystemDbContext : IDisposable
    {
        IDbSet<Movie> Movies { get; set; }

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
