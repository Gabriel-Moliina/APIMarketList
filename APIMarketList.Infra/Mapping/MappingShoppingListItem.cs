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

            builder.Property(p => p.Name)
                .HasColumnType("varchar(255)");
            
            builder.Property(p => p.Amount)
                .HasColumnType("int");

            builder.Property(p => p.Index)
                .HasColumnType("int");

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.ShoppingList)
                .WithMany(d => d.ShoppingListItens)
                .HasForeignKey(p => p.ShoppingListId);

            builder.Property<DateTime>("IncludedDate")
                .HasColumnType("datetime");
            builder.Property<DateTime>("ModifiedDate")
                .HasColumnType("datetime");
        }
    }
}
