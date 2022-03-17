using WebAppMovies.Repositories;
using WebAppMovies.Repositories.Interfaces;

namespace WebAppMovies.Units
{
    public interface IUnitOfWork:IDisposable
    {
        IDeveloperRepository Developers { get; }

        IProjectRepository Projects { get; }

        int Complete();
    }
}
