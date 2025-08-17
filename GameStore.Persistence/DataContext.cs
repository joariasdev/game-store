
using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameConsole> Consoles { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasDiscriminator<string>("Type")
                .HasValue<Game>("Game")
                .HasValue<GameConsole>("Console");

            base.OnModelCreating(modelBuilder);
        }
    }
}
