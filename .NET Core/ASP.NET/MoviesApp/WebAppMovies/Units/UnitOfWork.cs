using WebAppMovies.Contexts;
using WebAppMovies.Repositories;
using WebAppMovies.Repositories.Interfaces;

namespace WebAppMovies.Units
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Developers = new DeveloperRepository(_context);
            Projects = new ProjectRepository(_context);
        }

        public IDeveloperRepository Developers { get; private set; }

        public IProjectRepository Projects { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
