﻿using APIMarketList.Domain.Entities;
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
            builder.HasKey(p => p.Id).HasName("Id");

            builder.Property(p => p.IsAdmin)
                .HasColumnType("tinyint(1)");

            builder.HasOne(p => p.Group)
                .WithMany(d => d.Members)
                .HasForeignKey(p => p.GroupId);

            builder.HasOne(p => p.User)
                .WithMany(d => d.Members)
                .HasForeignKey(p => p.UserId);

            builder.Property(p => p.IncludedDate)
                .HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}