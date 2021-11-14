using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLite
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=sqlitedb1.db", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products", "test");         
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(k => k.ProductId);
                entity.HasIndex(i => i.PuroductName).IsUnique();
            });        

            modelBuilder.Entity<Customer>().ToTable("Customers", "test");

            modelBuilder.Entity<Order>().ToTable("Orders", "test");
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders)
                .OnDelete(DeleteBehavior.Cascade); // Включение каскадного удаления

            base.OnModelCreating(modelBuilder);
        }
    }
}