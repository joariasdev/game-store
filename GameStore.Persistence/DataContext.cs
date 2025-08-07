
using Microsoft.EntityFrameworkCore;
using GameStore.Domain;

namespace GameStore.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<GameConsole> Consoles { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
