namespace SFMS.Infrastructure.Persistence.Seeders;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SFMS.Domain.Entities;
using SFMS.Domain.Enums;
using SFMS.Infrastructure.Persistence.Context;

public static class ApplicationDbContextSeeder
{
    public static async Task SeedAsync(SFMSDbContext context)
    {
        try
        {
            // 1. Ensure migrations / database are applied
            await context.Database.MigrateAsync();
            Console.WriteLine("✓ Database migrations applied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error applying migrations: {ex.Message}");
            throw;
        }

        // 2. Seed Departments
        if (!await context.Departments.AnyAsync())
        {
            var departments = new List<Department>
            {
                new() { Name = "MARKETING" },
                new() { Name = "SUB CON" },
                new() { Name = "LOGISTIC" },
                new() { Name = "PRODUCTION" },
                new() { Name = "INFORMATION TECHNOLOGY" },
                new() { Name = "TSQA" }
            };

            await context.Departments.AddRangeAsync(departments);
            await context.SaveChangesAsync();
            Console.WriteLine("✓ Departments seeded successfully.");
        }
        else
        {
            Console.WriteLine("ℹ Departments already exist, skipping seed.");
        }

        // 3. Seed Sections
        if (!await context.Sections.AnyAsync())
        {
            var sections = new List<Section>
            {
                new() { Name = "MARKETING" },
                new() { Name = "SUB CON" },
                new() { Name = "ERECTING" },
                new() { Name = "DIGITAL PRESS" },
                new() { Name = "DIE CUTTING" },
                new() { Name = "COATING" },
                new() { Name = "LAMINATION" },
                new() { Name = "GLUING" },
                new() { Name = "INFORMATION TECHNOLOGY - SDG" },
                new() { Name = "MACHINE STRIPPING" },
                new() { Name = "FINISHING" },
                new() { Name = "PRODUCTION OFFICE" },
                new() { Name = "STRIPPING" },
                new() { Name = "OFFSET" },
                new() { Name = "INSPECTION MACHINE" },
                new() { Name = "CUTTING" },
                new() { Name = "QA" },
                new() { Name = "MANUAL FINISHING" },
                new() { Name = "PLANNING OFFICE" }
            };

            await context.Sections.AddRangeAsync(sections);
            await context.SaveChangesAsync();
            Console.WriteLine("✓ Sections seeded successfully.");
        }
        else
        {
            Console.WriteLine("ℹ Sections already exist, skipping seed.");
        }

        // 4. Seed Positions
        if (!await context.Positions.AnyAsync())
        {
            var positions = new List<Position>
            {
                new() { Name = "MARKETING" },
                new() { Name = "LINE LEADER" },
                new() { Name = "FEEDER" },
                new() { Name = "SYS. ANALYST PROG." },
                new() { Name = "ADMIN" },
                new() { Name = "SUPERVISOR" },
                new() { Name = "ASSISTANT SUPERVISOR" },
                new() { Name = "PICKER" },
                new() { Name = "SORTER" },
                new() { Name = "INSPECTOR" },
                new() { Name = "MATERIAL PLANNER" },
                new() { Name = "ASSISTENT OPERATOR" },
                new() { Name = "PACKER" },
                new() { Name = "SUPERINTENDENT" },
                new() { Name = "HELPER" },
                new() { Name = "OPERATOR" }
            };

            await context.Positions.AddRangeAsync(positions);
            await context.SaveChangesAsync();
            Console.WriteLine("✓ Positions seeded successfully.");
        }
        else
        {
            Console.WriteLine("ℹ Positions already exist, skipping seed.");
        }

        // 5. Seed Default User (matching your login test data)
        // CHANGED context.User to context.Users below:
        if (!await context.User.AnyAsync())
        {
            try
            {
                var passwordHasher = new PasswordHasher<User>();

                var defaultDept = await context.Departments.FirstAsync();
                var defaultSec = await context.Sections.FirstAsync();
                var defaultPos = await context.Positions.FirstAsync();

                var defaultPasswordHash = passwordHasher.HashPassword(null!, "pass123");

                // Fetch relevant lookup entities to satisfy foreign key IDs safely
                var department = await context.Departments.FirstAsync(d => d.Name == "INFORMATION TECHNOLOGY");
                var section = await context.Sections.FirstAsync(s => s.Name == "INFORMATION TECHNOLOGY - SDG");
                var position = await context.Positions.FirstAsync(p => p.Name == "SYS. ANALYST PROG.");

                var hashedPassword = passwordHasher.HashPassword(null!, "SA");

                var usersToSeed = new List<User>();

                // Generate 19 sample users dynamically
                for (int i = 1; i <= 19; i++)
                {
                    usersToSeed.Add(new User
                    {
                        Site = SiteEnums.PiSp,
                        EmployeeNumber = $"PPC-{i:D3}",
                        Name = $"Employee {i}",
                        DepartmentId = defaultDept.Id,
                        SectionId = defaultSec.Id,
                        PositionId = defaultPos.Id,
                        PasswordHash = defaultPasswordHash,
                        Role = UserRoleEnums.User,
                        IsActive = true,
                        Access = UserAccessEnums.Tagging,
                        Rights = UserRightsEnums.View,
                        Signature = null,
                    });
                }

                var defaultUser = new User
                {
                    Site = SiteEnums.PiSp,
                    EmployeeNumber = "SA",
                    Name = "System Administrator",
                    DepartmentId = department.Id,
                    SectionId = section.Id,
                    PositionId = position.Id,
                    PasswordHash = hashedPassword,
                    Role = UserRoleEnums.Superadmin,
                    IsActive = true,
                    Access = UserAccessEnums.Tagging,
                    Rights = UserRightsEnums.All,
                    Signature = null
                };
                usersToSeed.Add(defaultUser);

                // CHANGED context.User to context.Users below:
                await context.User.AddRangeAsync(usersToSeed);
                await context.SaveChangesAsync();
                Console.WriteLine("✓ Default user 'SA' seeded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error seeding default user: {ex.Message}");
                throw;
            }
        }
        else
        {
            Console.WriteLine("ℹ Users already exist, skipping seed.");
        }
    }
}