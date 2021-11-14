using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLite
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
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
            base.OnModelCreating(modelBuilder);
        }
    }
}