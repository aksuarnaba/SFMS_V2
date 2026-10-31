using Microsoft.EntityFrameworkCore;
using SFMS.Application.Common.Interfaces;
using SFMS.Domain.Common;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Data
{
    public class PalletTaggingDbContext : DbContext
    {
        public PalletTaggingDbContext(DbContextOptions<PalletTaggingDbContext> options) : base(options) { }

        public DbSet<UserEntities> Users => Set<UserEntities>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<BaseEvent>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PalletTaggingDbContext).Assembly);
        }
    }
}
