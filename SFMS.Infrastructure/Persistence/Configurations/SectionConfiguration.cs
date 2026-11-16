using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Persistence.Configurations
{
    public sealed class SectionConfiguration
    : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DepartmentId)
                .IsRequired();

            builder.HasIndex(x => new
            {
                x.DepartmentId,
                x.Code
            }).IsUnique();

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
