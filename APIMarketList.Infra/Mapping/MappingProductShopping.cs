using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMarketList.Infra.Data.Mapping
{
    public class MappingProductShopping : IEntityTypeConfiguration<ProductShopping>
    {
        public void Configure(EntityTypeBuilder<ProductShopping> builder)
        {
            builder.ToTable("ProductShopping");
            builder.Property(p => p.Id);

            builder.HasKey(p => p.Id).HasName("Id");

            builder.HasOne(p => p.Shopping)
                .WithMany(d => d.ProductShoppings)
                .HasForeignKey(p => p.ShoppingId);

            builder.HasOne(p => p.Product)
                .WithMany(d => d.ProductShoppings)
                .HasForeignKey(p => p.ProductId);

            builder.Property(p => p.IncludedDate)
            .   HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
