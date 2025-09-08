using Microsoft.EntityFrameworkCore;
using Entity_Framework.Models;

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
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<StudentBook> StudentBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Department>().Property(x => x.desc).IsRequired();
            //modelBuilder.Entity<Department>()
            //    .HasMany(s => s.Students)
            //    .WithOne(d => d.department)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Student>()
            //    .HasOne(d => d.grade)
            //    .WithOne(g => g.Student)
            //    .OnDelete(DeleteBehavior.Restrict);


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().
                SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.Ignore<Attendance>(); 
            //[NotMapped]

            //modelBuilder.Entity<Attendance>();
            //public ICollection<Attendance> attendances { get; set; }
            //modelBuilder.Entity<Attendance>().ToTable("atts", a => a.ExcludeFromMigrations());


        }
    }
}
