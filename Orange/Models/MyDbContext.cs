using Microsoft.EntityFrameworkCore;

namespace Orange.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        // Add a DbSet for the Department table
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=DESKTOP-5AU1IL4;Database=Orange;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07A06A2FEE");
                entity.HasIndex(e => e.Email, "UQ__Users__A9D1053400E89EAD").IsUnique();
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            // Additional model configurations if necessary
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
