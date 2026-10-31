using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace SFMS.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntities>
    {
        public void Configure(EntityTypeBuilder<UserEntities> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Emp_num)
                .IsUnique();

            builder.Property(e => e.Site)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Emp_num)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Dept)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Section)
                .HasMaxLength(100);

            builder.Property(e => e.Position)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(e => e.Role)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(e => e.Access)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.Rights)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.Signature)
                .HasColumnType("NVARCHAR(MAX)");
        }
    }
}

