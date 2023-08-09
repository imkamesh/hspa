using Microsoft.EntityFrameworkCore;
using PropertyAPI.Models;

namespace PropertyAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
    }
}
