using MS.Data.Repositories;

namespace MS.Data.Abstraction
{
    public interface IMovieSystemData
    {
        MovieRepository Movies { get; }

        int SaveChanges();
    }
}
