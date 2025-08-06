
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
