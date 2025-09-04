using Microsoft.EntityFrameworkCore;

namespace Entity_Framework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Connections.ConnectionString);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
