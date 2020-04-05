using DigitalSales.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalSales.Data.Mapping.Sales
{
    public class DetailSaleMap : IEntityTypeConfiguration<DetailSale>
    {
        public void Configure(EntityTypeBuilder<DetailSale> builder)
        {
            builder.ToTable("detail_sale")
                .HasKey(d => d.iddetail_sale);
        }
    }
}
