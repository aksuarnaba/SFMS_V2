using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Persistence.Configurations
{ 
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            // Site
            builder.Property(x => x.Site)
                .IsRequired()
                .HasConversion<int>();

            // Employee Number
            builder.Property(x => x.EmployeeNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            // Employee Name
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            // Password
            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            // Role
            builder.Property(x => x.Role)
                .IsRequired()
                .HasConversion<int>();

            // Active Status
            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            // Signature
            builder.Property(x => x.Signature)
                .HasMaxLength(500);

            // Unique employee number within a site
            builder.HasIndex(x => new
            {
                x.Site,
                x.EmployeeNumber
            })
            .IsUnique();

            // User -> Department
            builder.HasOne(x => x.Department)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Section
            builder.HasOne(x => x.Section)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Position
            builder.HasOne(x => x.Position)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
