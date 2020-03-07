using DigitalSales.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalSales.Data.Mapping.Users
{
    public class UserMap : IEntityTypeConfiguration<Entities.Users.User>
    {
        public void Configure(EntityTypeBuilder<Entities.Users.User> builder)
        {
            builder.ToTable("users")
                 .HasKey(u => u.idUser);

            builder.HasOne(d => d.Role)
                  .WithMany(p => p.Users)
                  .HasForeignKey(d => d.idRole);

        }
    }
}
