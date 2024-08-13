using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMarketList.Infra.Data.Mapping
{
    public class MappingShoppingListItem : IEntityTypeConfiguration<ShoppingListItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingListItem> builder)
        {
            builder.ToTable("ShoppingListItem");

            builder.Property(p => p.Id);
            builder.HasKey(p => p.Id).HasName("Id");

            builder.Property(p => p.Amount)
                .HasColumnType("int(11)");

            builder.HasOne(p => p.Product)
                .WithMany(d => d.ShoppingListItems)
                .HasForeignKey(p => p.ProductId);
            
            builder.HasOne(p => p.ShoppingList)
                .WithMany(d => d.ShoppingListItens)
                .HasForeignKey(p => p.ShoppingListId);

            builder.Property(p => p.IncludedDate)
                .HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
