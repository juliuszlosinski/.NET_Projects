using Microsoft.EntityFrameworkCore;
using WebBooks.Models;

namespace WebBooks.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        { 
        }

        public DbSet<Category> Categories { get; set; } 
    }
}
