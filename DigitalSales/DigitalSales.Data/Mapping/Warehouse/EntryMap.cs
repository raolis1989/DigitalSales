using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalSales.Data.Mapping.Warehouse
{
    public class EntryMap : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.ToTable("entry")
                .HasKey(i => i.identry);

            builder.HasOne(i => i.Person)
                .WithMany(p => p.Entries)
                .HasForeignKey(i => i.idprovider);

            builder.HasOne(i => i.User)
                .WithMany(p => p.Entries)
                .HasForeignKey(i => i.iduser);

            builder.HasMany(x => x.detail_entry)
                .WithOne(x => x.Entry)
                .HasForeignKey(x=>x.identry);
                

        }
    }
}
