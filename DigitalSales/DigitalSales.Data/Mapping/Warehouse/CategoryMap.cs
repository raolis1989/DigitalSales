using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalSales.Data.Mapping.Warehouse
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category")
                .HasKey(c => c.IdCategory);

            builder.Property(c => c.Name)
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .HasMaxLength(256);
        }
    }
}
