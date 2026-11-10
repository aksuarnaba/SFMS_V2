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
    public class UserRepository : IUserRepository
    {

        private readonly SFMSDbContext _context;

        public UserRepository(SFMSDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetByEmployeeNumberAsync(SiteEnums site, string employeeNumber, CancellationToken ct = default)
        {
            return _context.User
                .AsNoTracking()
                .SingleOrDefaultAsync(
                user => user.Site == site &&
                        user.EmployeeNumber == employeeNumber,
                    ct);
        }
    }
}
