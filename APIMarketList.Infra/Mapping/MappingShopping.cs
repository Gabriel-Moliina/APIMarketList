using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMarketList.Infra.Data.Mapping
{
    public class MappingShopping : IEntityTypeConfiguration<Shopping>
    {
        public void Configure(EntityTypeBuilder<Shopping> builder)
        {
            builder.ToTable("Shopping");

            builder.Property(p => p.Paid)
                .HasColumnType("tinyint(1)")
                .HasDefaultValueSql("0");

            builder.Property(p => p.PaidDate)
                .HasColumnType("datetime")
                .HasDefaultValue(null);

            builder.HasOne(p => p.User)
                .WithMany(d => d.Shoppings)
                .HasForeignKey(p => p.UserId);

            builder.Property(p => p.IncludedDate)
                .HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
