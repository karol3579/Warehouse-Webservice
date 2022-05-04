using Microsoft.EntityFrameworkCore;
using Common.Entities;

namespace Common.Repositories{
    public class SqlRepository : DbContext{
        private string _ConnectionString = "server=localhost;database=Warehouse;user=root;password=secret";
        public DbSet<Product> Product {get; set;}
        public DbSet<Stock> Stock {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Stock>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseMySql(_ConnectionString,ServerVersion.AutoDetect(_ConnectionString));
        }

    }
}