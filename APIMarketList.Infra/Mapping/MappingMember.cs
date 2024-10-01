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

            builder.Property(p => p.IsAdmin)
                .HasColumnType("bit");
            
            builder.Property(p => p.CanUpdate)
                .HasColumnType("bit");

            builder.HasOne(p => p.Group)
                .WithMany(d => d.Members)
                .HasForeignKey(p => p.GroupId);

            builder.HasOne(p => p.User)
                .WithMany(d => d.Members)
                .HasForeignKey(p => p.UserId);

            builder.Property<DateTime>("IncludedDate")
                .HasColumnType("datetime");
            builder.Property<DateTime>("ModifiedDate")
                .HasColumnType("datetime");
        }
    }
}
