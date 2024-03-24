using AutomapperPlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomapperPlayground
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
