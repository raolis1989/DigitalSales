using DigitalSales.Data.Mapping;
using DigitalSales.Data.Mapping.Sales;
using DigitalSales.Data.Mapping.Users;
using DigitalSales.Data.Mapping.Warehouse;
using DigitalSales.Entities.Sales;
using DigitalSales.Entities.Users;
using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace DigitalSales.Data
{
    public class DbContextDigitalSales: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<DetailEntry> DetailEntries { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<DetailSale> DetailSales { get; set; }

        public DbContextDigitalSales(DbContextOptions<DbContextDigitalSales> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new EntryMap());
            modelBuilder.ApplyConfiguration(new DetailEntryMap());
            modelBuilder.ApplyConfiguration(new SaleMap());
            modelBuilder.ApplyConfiguration(new DetailSaleMap());


        }
    }
}
