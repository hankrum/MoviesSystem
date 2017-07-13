using MS.Data.Repositories.Abstraction;
using MS.Models;
using MS.Data.Abstraction;

namespace MS.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IRepository<Movie>
    {
        public MovieRepository(IMovieSystemDbContext context)
            : base(context)
        {
        }
    }
}
