using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalSales.Data.Mapping.Warehouse
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("article")
                .HasKey(a => a.IdArticle);

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Articles)
                .HasForeignKey(d => d.idCategory);

            builder.HasMany(x => x.DetailEntry)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.idarticle);

        }
    }
}
