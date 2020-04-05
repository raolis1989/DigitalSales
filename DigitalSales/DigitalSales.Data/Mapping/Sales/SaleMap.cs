using DigitalSales.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalSales.Data.Mapping.Sales
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("sale")
                .HasKey(i => i.idsale);

            builder.HasOne(i => i.Person)
                .WithMany(p => p.Sales)
                .HasForeignKey(i => i.idclient);

            builder.HasOne(i => i.User)
             .WithMany(p => p.Sales)
             .HasForeignKey(i => i.iduser);

            builder.HasMany(x => x.detail_sale)
                .WithOne(x => x.Sale)
                .HasForeignKey(x => x.idsale);
        }
    }
}
