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

            builder.HasKey(p => p.Id).HasName("Id");

            builder.Property(p => p.Description)
                .HasColumnType("varchar(255)");

            builder.Property(p => p.ListDate)
                .HasColumnType("datetime");

            builder.Property(p => p.GroupId)
                .HasColumnType("bigint(11)");

            builder.Property(p => p.Status)
                .HasColumnType("int(5)");

            builder.HasOne(p => p.Group)
                .WithMany(d => d.ShoppingLists)
                .HasForeignKey(p => p.GroupId);

            builder.Property(p => p.IncludedDate)
            .   HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
