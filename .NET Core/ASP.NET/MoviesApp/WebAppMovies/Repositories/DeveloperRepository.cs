using WebAppMovies.Contexts;
using WebAppMovies.Models;
using WebAppMovies.Repositories.Interfaces;

namespace WebAppMovies.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationContext context):base(context) { }

        public IEnumerable<Developer> GetPopularDevelopers(int count)
        {
            return _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
        }
    }
}
