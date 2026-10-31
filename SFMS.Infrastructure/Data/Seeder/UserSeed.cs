using Microsoft.EntityFrameworkCore;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using SFMS.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace SFMS.Infrastructure.Data.Seeder
{
    public static class UserSeed
    {
        public static async Task SeedAsync(PalletTaggingDbContext context)
        {
            if(!await context.Users.AnyAsync())
            {
                var superadmin = new UserEntities
                {
                    Site = "PI-SP",
                    Emp_num = "sa",
                    Name = "System Administrator",
                    Dept = "IT",
                    Section = "Admin",
                    Position = "System Analyst",
                    IsActive = true,
                    Access = AccessEnums.All,
                    Rights = RightsEnums.All,
                    Signature = string.Empty,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "System"
                };

                var passwordHasher = new PasswordHasher<UserEntities>();
                superadmin.PasswordHash = passwordHasher.HashPassword(superadmin, "Password123");

                await context.Users.AddAsync(superadmin);
                await context.SaveChangesAsync();
            }
        }
    }
}
