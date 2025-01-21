using Microsoft.EntityFrameworkCore;
using BackEndCompas.Models;

namespace BackEndCompas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producto>  Productos { get; set; }
    }
}
