using Microsoft.EntityFrameworkCore;
using WebAppMovies.Models;

namespace WebAppMovies.Contexts
{
    public class ApplicationContext : DbContext
    {
#pragma warning disable CS8618 // Pole niedopuszczające wartości null musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie pola jako dopuszczającego wartość null.
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
#pragma warning restore CS8618 // Pole niedopuszczające wartości null musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie pola jako dopuszczającego wartość null.

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
