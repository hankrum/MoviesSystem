using MS.Data.Abstraction;
using MS.Data.Repositories;
using MS.Data.Repositories.Abstraction;
using MS.Models;
using System;
using System.Collections.Generic;

namespace MS.Data
{
    public class MovieSystemData : IMovieSystemData
    {
        private readonly IMovieSystemDbContext _context;
        private readonly IDictionary<Type, object> _repositories;

        public MovieSystemData()
            : this(new MovieSystemDbContext())
        {
        }

        public MovieSystemData(IMovieSystemDbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        public MovieRepository Movies =>
            (MovieRepository)this.GetRepository<Movie>();


        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var repositoryType = typeof(T);

            if (!this._repositories.ContainsKey(repositoryType))
            {
                var type = typeof(GenericRepository<T>);

                this.SetType(repositoryType, ref type);

                this._repositories.Add(repositoryType, Activator.CreateInstance(type, this._context));
            }

            return (IRepository<T>)this._repositories[repositoryType];
        }

        private void SetType(Type repositoryType, ref Type type)
        {
            if (repositoryType.IsAssignableFrom(typeof(Movie)))
                type = typeof(MovieRepository);
        }
    }
}
