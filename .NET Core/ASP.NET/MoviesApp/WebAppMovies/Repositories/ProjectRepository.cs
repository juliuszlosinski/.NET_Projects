using WebAppMovies.Contexts;
using WebAppMovies.Models;

namespace WebAppMovies.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context):base(context)
        {
        }
    }
}
