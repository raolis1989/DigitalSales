﻿using DigitalSales.Data.Mapping.Warehouse;
using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace DigitalSales.Data
{
    public class DbContextDigitalSales: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbContextDigitalSales(DbContextOptions<DbContextDigitalSales> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}