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
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Uniform> Uniforms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Department>().Property(x => x.desc).IsRequired();
            //modelBuilder.Entity<Department>()
            //    .HasMany(s => s.Students)
            //    .WithOne(d => d.department)
            //    .OnDelete(Dele++te++++++++++++q1qw    +Behavior.Restrict);

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

            modelBuilder.Entity<Invoice>().Property(x => x.quantity)
                .HasDefaultValue(1);
            modelBuilder.Entity<Invoice>().Property(x => x.createdDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Invoice>().Property(x => x.fullName)
                .HasComputedColumnSql("[customerTitle] + ' ' + [customerName]");

            modelBuilder.Entity<Invoice>().Property(x => x.total)
                 .HasComputedColumnSql("[price] + ' ' + [quantity]");

            modelBuilder.Entity<Student>().HasIndex(s => s.Name).IsUnique().HasFilter("Name is not null");

            modelBuilder.HasSequence<int>("DeiveryOrder").StartsAt(103).IncrementsBy(1);
            modelBuilder.Entity<Book>().Property(x => x.DeiveryOrder).HasDefaultValueSql("Next Value For DeiveryOrder");
            modelBuilder.Entity<Uniform>().Property(x => x.DeiveryOrder).HasDefaultValueSql("Next Value For DeiveryOrder");

            modelBuilder.Entity<Gender>().HasData(new Gender() { Id = 1, genderName = "Male" } 
                         ,new Gender() { Id = 2, genderName = "Female"});
            // seed table date must be implemented befor the tables that use it as forgien key.
            // ?? search about (seed), it's not used a lot.



        }
    }
}
 