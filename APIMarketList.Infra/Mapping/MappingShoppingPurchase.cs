using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMarketList.Infra.Data.Mapping
{
    public class MappingShoppingPurchase : IEntityTypeConfiguration<ShoppingPurchase>
    {
        public void Configure(EntityTypeBuilder<ShoppingPurchase> builder)
        {
            builder.ToTable("ShoppingPurchase");

            builder.Property(p => p.Id);

            builder.Property(p => p.QuantityPurchased)
                .HasColumnType("int")
                .HasDefaultValue(0);
            
            builder.Property(p => p.PurchaseDate)
                .HasColumnType("datetime");

            builder.HasOne(p => p.ShoppingListItem)
                .WithMany(d => d.ShoppingPurchases)
                .HasForeignKey(p => p.ShoppingListItemId);

            builder.Property(p => p.IncludedDate)
                .HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
