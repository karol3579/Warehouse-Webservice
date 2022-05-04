using Microsoft.EntityFrameworkCore;
using DocumentsManager.Service.Entities;

namespace DocumentsManager.Service.Repositories{
    public class sqlRepository : DbContext{
        private string _connectionString="server=localhost;database=DocumentsManager;user=root;password=secret";

        public DbSet<Customer> Customers;
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Customer>();  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }

    }
}