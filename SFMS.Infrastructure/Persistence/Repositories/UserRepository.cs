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

        public Task<User?> GetByEmployeeNumberAsync(SiteEnums site, string employeeNumber, CancellationToken ct = default)
        {
            return _context.User
                .AsNoTracking()
                .SingleOrDefaultAsync(
                user => user.Site == site &&
                        user.EmployeeNumber == employeeNumber,
                    ct);
        }

        public async Task<(IReadOnlyList<User> Users, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
            {
                var query = _context.User
                    .AsNoTracking();

                var totalCount = await query.CountAsync(cancellationToken);

                var users = await query
                    .Include(x => x.Department)
                    .Include(x => x.Section)
                    .Include(x => x.Position)
                    .OrderBy(x => x.EmployeeNumber)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                return (users, totalCount);
                
        }
    }
}
