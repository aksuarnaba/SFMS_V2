using Microsoft.EntityFrameworkCore;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Persistence.Context
{
    public class SFMSDbContext : DbContext
    {
        public SFMSDbContext(DbContextOptions<SFMSDbContext> options) : base(options)
        {

        }

        public DbSet<User> User => Set<User>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Section> Sections => Set<Section>();
        public DbSet<Position> Positions => Set<Position>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SFMSDbContext).Assembly);
        }
    }
}
