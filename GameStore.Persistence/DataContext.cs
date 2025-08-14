
using Microsoft.EntityFrameworkCore;
using GameStore.Domain.Entities;

namespace GameStore.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
