using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalSales.Data.Mapping.Warehouse
{
    public class DetailEntryMap : IEntityTypeConfiguration<DetailEntry>
    {
        public void Configure(EntityTypeBuilder<DetailEntry> builder)
        {
            builder.ToTable("detail_entry")
                .HasKey(d => d.iddetail_entry);

        }
    }
}
