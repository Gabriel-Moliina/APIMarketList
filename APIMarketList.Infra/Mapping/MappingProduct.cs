using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMarketList.Infra.Data.Mapping
{
    public class MappingProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(p => p.Id);
            builder.HasKey(p => p.Id).HasName("Id");

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Name)
                .HasColumnType("varchar(150)");

            builder.Property(p => p.IncludedDate)
                .HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
