using MS.Data.Abstraction;
using MS.Data.Migrations;
using MS.Models;
using System.Data.Entity;

namespace MS.Data
{
    public class MovieSystemDbContext : DbContext, IMovieSystemDbContext
    {
        public MovieSystemDbContext() : base("MovieSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieSystemDbContext, Configuration>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<MovieSystemDbContext>());
        }

        public virtual IDbSet<Movie> Movies { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
