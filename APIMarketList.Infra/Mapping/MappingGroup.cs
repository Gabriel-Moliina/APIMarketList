using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMarketList.Infra.Data.Mapping
{
    public class MappingGroup : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.Property(p => p.Id);
            builder.HasKey(p => p.Id).HasName("Id");

            builder.Property(p => p.Description)
                .HasColumnType("varchar(255)");

            builder.Property(p => p.IncludedDate)
                .HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
