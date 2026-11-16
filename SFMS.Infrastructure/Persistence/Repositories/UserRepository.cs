using Microsoft.EntityFrameworkCore;
using SFMS.Application.Common.Interfaces.Persistence;
using SFMS.Domain.Entities;
using SFMS.Domain.Enums;
using SFMS.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Persistence.Repositories
{
    public class UserRepository(SFMSDbContext context) : IUserRepository
    {

        private readonly SFMSDbContext _context = context;

    public Task<User?> GetByEmployeeNumberAsync(
        SiteEnums site,
        string employeeNumber,
        CancellationToken cancellationToken = default)
    {
        var normalizedEmployeeNumber =
            employeeNumber
                .Trim()
                .ToUpperInvariant();

        return _context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(
                user =>
                    user.Site == site &&
                    user.EmployeeNumber ==
                        normalizedEmployeeNumber,
                cancellationToken);
    }

        //public async Task<(
        //    IReadOnlyList<User> Users,
        //    int TotalCount)> GetPagedAsync(
        //        int pageNumber,
        //        int pageSize,
        //        CancellationToken cancellationToken = default)
        //    {
        //        var query = _context.Users
        //            .AsNoTracking();

        //        var totalCount = await query.CountAsync(
        //            cancellationToken);

        //        var users = await query
        //            .Include(x => x.Department)
        //            .Include(x => x.Section)
        //            .Include(x => x.Position)

        //            .OrderBy(x => x.Site)
        //            .ThenBy(x => x.EmployeeNumber)
        //            .ThenBy(x => x.Id)

        //            .Skip((pageNumber - 1) * pageSize)
        //            .Take(pageSize)

        //            .ToListAsync(cancellationToken);

        //        return (users, totalCount);
        //    }

        public async Task<(
        IReadOnlyList<User> Users,
        int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            // 1. Get the total count efficiently
            var totalCount = await _context.Users
                .CountAsync(cancellationToken);

            // 2. Calculate row bounds for SQL Server 2008 R2 ROW_NUMBER()
            int startRow = (pageNumber - 1) * pageSize + 1;
            int endRow = pageNumber * pageSize;

            // 3. Query using native SQL Server 2008 R2 paging
            var users = await _context.Users
                .FromSqlRaw(@"
                SELECT * FROM (
                    SELECT ROW_NUMBER() OVER (ORDER BY Site, EmployeeNumber, Id) AS RowNum, *
                    FROM Users
                ) AS PagedUsers
                WHERE RowNum BETWEEN {0} AND {1}", startRow, endRow)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return (users, totalCount);
        }


    }
}
