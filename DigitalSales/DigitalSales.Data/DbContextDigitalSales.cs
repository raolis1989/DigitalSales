using Microsoft.EntityFrameworkCore;

namespace DigitalSales.Data
{
    public class DbContextDigitalSales: DbContext
    {
        public DbContextDigitalSales(DbContextOptions<DbContextDigitalSales> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
