using Microsoft.EntityFrameworkCore;
using SFMS.Application.Interfaces;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Data
{
    public class PalletTaggingDbContext : DbContext, IPalletTaggingDbContext
    {
        public PalletTaggingDbContext(DbContextOptions<PalletTaggingDbContext> options) : base(options) { }

        public DbSet<EmployeeEntities> Employees => Set<EmployeeEntities>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PalletTaggingDbContext).Assembly);
        }
    }
}
