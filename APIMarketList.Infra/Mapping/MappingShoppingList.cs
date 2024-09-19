using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMarketList.Infra.Data.Mapping
{
    public class MappingShoppingList : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.ToTable("ShoppingList");
            builder.Property(p => p.Id);

            builder.Property(p => p.Description)
                .HasColumnType("varchar(255)");

            builder.Property(p => p.ListDate)
                .HasColumnType("datetime");

            builder.Property(p => p.GroupId)
                .HasColumnType("int");

            builder.Property(p => p.Status)
                .HasColumnType("int");

            builder.HasOne(p => p.Group)
                .WithMany(d => d.ShoppingLists)
                .HasForeignKey(p => p.GroupId);

            builder.Property<DateTime>("IncludedDate")
            .   HasColumnType("datetime");
            builder.Property<DateTime>("ModifiedDate")
                .HasColumnType("datetime");
        }
    }
}
