using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMarketList.Infra.Data.Mapping
{
    public class MappingMember : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");

            builder.Property(p => p.Id);

            builder.HasOne(p => p.User)
                .WithMany(d => d.Members)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.ShoppingList)
                .WithMany(d => d.Members)
                .HasForeignKey(p => p.ShoppingListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property<DateTime>("IncludedDate")
                .HasColumnType("datetime");
            builder.Property<DateTime>("ModifiedDate")
                .HasColumnType("datetime");
        }
    }
}
