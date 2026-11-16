namespace SFMS.Infrastructure.Persistence.Seeders;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SFMS.Application.Common.Interfaces.Security;
using SFMS.Domain.Entities;
using SFMS.Domain.Enums;
using SFMS.Infrastructure.Persistence.Context;

public static class SFMSDbContextSeeder
{
    public static async Task SeedAsync(
        SFMSDbContext context,
        IPasswordHasher passwordHasher,
        string? initialAdminPassword,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(passwordHasher);

        await SeedDepartmentsAsync(
            context,
            cancellationToken);

        await SeedSectionsAsync(
            context,
            cancellationToken);

        await SeedPositionsAsync(
            context,
            cancellationToken);

        await SeedInitialAdministratorAsync(
            context,
            passwordHasher,
            initialAdminPassword,
            cancellationToken);
    }

    private static async Task SeedDepartmentsAsync(
        SFMSDbContext context,
        CancellationToken cancellationToken)
    {
        var departments = new[]
        {
        new Department(
            "MKT",
            "MARKETING"),

        new Department(
            "LOG",
            "LOGISTIC"),

        new Department(
            "PROD",
            "PRODUCTION"),

        new Department(
            "IT",
            "INFORMATION TECHNOLOGY"),

        new Department(
            "TSQA",
            "TECHNICAL SERVICES AND QUALITY ASSURANCE")
    };

        foreach (var department in departments)
        {
            var exists = await context.Departments
                .AnyAsync(
                    existing =>
                        existing.Code == department.Code,
                    cancellationToken);

            if (!exists)
            {
                await context.Departments.AddAsync(
                    department,
                    cancellationToken);
            }
        }

        await context.SaveChangesAsync(
            cancellationToken);
    }

    private static async Task SeedSectionsAsync(
        SFMSDbContext context,
        CancellationToken cancellationToken)
    {
        var marketingDepartmentId =
            await GetDepartmentIdAsync(
                context,
                "MKT",
                cancellationToken);

        var logisticsDepartmentId =
            await GetDepartmentIdAsync(
                context,
                "LOG",
                cancellationToken);

        var productionDepartmentId =
            await GetDepartmentIdAsync(
                context,
                "PROD",
                cancellationToken);

        var informationTechnologyDepartmentId =
            await GetDepartmentIdAsync(
                context,
                "IT",
                cancellationToken);

        var tsqaDepartmentId =
            await GetDepartmentIdAsync(
                context,
                "TSQA",
                cancellationToken);

        var sections = new[]
        {

        new Section(
            "SUB",
            "SUB CON",
            productionDepartmentId),

        new Section(
            "ERE",
            "ERECTING",
            productionDepartmentId),

        new Section(
            "DGP",
            "DIGITAL PRESS",
            productionDepartmentId),

        new Section(
            "DI",
            "DIE CUTTING",
            productionDepartmentId),

        new Section(
            "COA",
            "COATING",
            productionDepartmentId),

        new Section(
            "LAM",
            "LAMINATION",
            productionDepartmentId),

        new Section(
            "GLU",
            "GLUING",
            productionDepartmentId),

        new Section(
            "SDG",
            "INFORMATION TECHNOLOGY - SDG",
            informationTechnologyDepartmentId),

        new Section(
            "MSTR",
            "MACHINE STRIPPING",
            productionDepartmentId),

        new Section(
            "FIN",
            "FINISHING",
            productionDepartmentId),

        new Section(
            "PROD",
            "PRODUCTION OFFICE",
            productionDepartmentId),

        new Section(
            "STR",
            "STRIPPING",
            productionDepartmentId),

        new Section(
            "OFF",
            "OFFSET",
            productionDepartmentId),

        new Section(
            "QA",
            "INSPECTION MACHINE",
            tsqaDepartmentId),

        new Section(
            "CUT",
            "CUTTING",
            productionDepartmentId),

        new Section(
            "MF",
            "MANUAL FINISHING",
            productionDepartmentId),

        new Section(
            "PLA",
            "PLANNING OFFICE",
            productionDepartmentId),

        new Section(
            "LOGI",
            "LOGISTICS",
            logisticsDepartmentId)
    };

        foreach (var section in sections)
        {
            var exists = await context.Sections
                .AnyAsync(
                    existing =>
                        existing.DepartmentId ==
                            section.DepartmentId &&
                        existing.Code == section.Code,
                    cancellationToken);

            if (!exists)
            {
                await context.Sections.AddAsync(
                    section,
                    cancellationToken);
            }
        }

        await context.SaveChangesAsync(
            cancellationToken);
    }

    private static async Task SeedPositionsAsync(
        SFMSDbContext context,
        CancellationToken cancellationToken)
    {
        var positions = new[]
        {
        new Position(
            "MARKETING",
            "MARKETING"),

        new Position(
            "LL",
            "LINE LEADER"),

        new Position(
            "FEED",
            "FEEDER"),

        new Position(
            "SYSPROG",
            "SYS. ANALYST PROG."),

        new Position(
            "ADMIN",
            "ADMIN"),

        new Position(
            "SV",
            "SUPERVISOR"),

        new Position(
            "ASV",
            "ASSISTANT SUPERVISOR"),

        new Position(
            "PIC",
            "PICKER"),

        new Position(
            "SRT",
            "SORTER"),

        new Position(
            "INSP",
            "INSPECTOR"),

        new Position(
            "MTPL",
            "MATERIAL PLANNER"),

        new Position(
            "AOP",
            "ASSISTANT OPERATOR"),

        new Position(
            "PACK",
            "PACKER"),

        new Position(
            "SI",
            "SUPERINTENDENT"),

        new Position(
            "HELP",
            "HELPER"),

        new Position(
            "OPE",
            "OPERATOR")
    };

        foreach (var position in positions)
        {
            var exists = await context.Positions
                .AnyAsync(
                    existing =>
                        existing.Code == position.Code,
                    cancellationToken);

            if (!exists)
            {
                await context.Positions.AddAsync(
                    position,
                    cancellationToken);
            }
        }

        await context.SaveChangesAsync(
            cancellationToken);
    }

    private static async Task SeedInitialAdministratorAsync(
        SFMSDbContext context,
        IPasswordHasher passwordHasher,
        string? initialAdminPassword,
        CancellationToken cancellationToken)
    {
        var administratorExists = await context.Users
            .AnyAsync(
                user =>
                    user.Site == SiteEnums.PiSp &&
                    user.EmployeeNumber == "SA",
                cancellationToken);

        if (administratorExists)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(initialAdminPassword))
        {
            throw new InvalidOperationException(
                "The initial SFMS administrator does not exist, " +
                "but no InitialAdmin password was configured.");
        }

        var departmentId = await GetDepartmentIdAsync(
            context,
            "IT",
            cancellationToken);

        var sectionId = await GetSectionIdAsync(
            context,
            departmentId,
            "SDG",
            cancellationToken);

        var positionId = await GetPositionIdAsync(
            context,
            "SYSPROG",
            cancellationToken);

        var passwordHash = passwordHasher.HashPassword(
            initialAdminPassword);

        var administrator = new User(
            SiteEnums.PiSp,
            "SA",
            "SYSTEM ADMINISTRATOR",
            departmentId,
            sectionId,
            positionId,
            passwordHash,
            UserRoleEnums.Superadmin);

        administrator.SetCreatedAudit("SYSTEM");

        await context.Users.AddAsync(
            administrator,
            cancellationToken);

        await context.SaveChangesAsync(
            cancellationToken);
    }

    private static async Task<Guid> GetDepartmentIdAsync(
        SFMSDbContext context,
        string departmentCode,
        CancellationToken cancellationToken)
    {

        var department = await context.Departments.FirstOrDefaultAsync(d => d.Code == departmentCode, cancellationToken: cancellationToken);

        return department == null
            ? throw new InvalidOperationException($"Required Department with code '{departmentCode}' was not found during seeding. Please ensure departments are seeded first.")
            : await context.Departments
            .Where(
                department =>
                    department.Code == departmentCode)
            .Select(
                department =>
                    department.Id)
            .SingleAsync(cancellationToken);
    }

    private static async Task<Guid> GetSectionIdAsync(
        SFMSDbContext context,
        Guid departmentId,
        string sectionCode,
        CancellationToken cancellationToken)
    {
        return await context.Sections
            .Where(
                section =>
                    section.DepartmentId == departmentId &&
                    section.Code == sectionCode)
            .Select(
                section =>
                    section.Id)
            .SingleAsync(cancellationToken);
    }

    private static async Task<Guid> GetPositionIdAsync(
        SFMSDbContext context,
        string positionCode,
        CancellationToken cancellationToken)
    {
        return await context.Positions
            .Where(
                position =>
                    position.Code == positionCode)
            .Select(
                position =>
                    position.Id)
            .SingleAsync(cancellationToken);
    }
}