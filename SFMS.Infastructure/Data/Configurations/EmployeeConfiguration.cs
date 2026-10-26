using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntities>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntities> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Site)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Emp_num)
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(e => e.Dept)
                .HasMaxLength(100);

            builder.Property(e => e.Section)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Role)
                .HasMaxLength(100)
                .IsRequired()
                .HasConversion<string>();
        }
    }
}
