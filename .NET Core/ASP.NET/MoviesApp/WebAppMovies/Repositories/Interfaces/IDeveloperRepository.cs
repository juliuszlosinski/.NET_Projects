using WebAppMovies.Models;

namespace WebAppMovies.Repositories.Interfaces
{
    public interface IDeveloperRepository: IGenericRepository<Developer>
    {
        IEnumerable<Developer> GetPopularDevelopers(int count);
    }
}
