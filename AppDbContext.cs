using Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Connections.ConnectionString);
        }

        public DbSet<Shared.Models.Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
