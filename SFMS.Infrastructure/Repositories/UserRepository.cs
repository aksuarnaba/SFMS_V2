using Microsoft.EntityFrameworkCore;
using SFMS.Application.Common.Interfaces;
using SFMS.Domain.Entities;
using SFMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PalletTaggingDbContext _context;

        public UserRepository(PalletTaggingDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntities?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id, ct);
        }

        public async Task<UserEntities?> GetByEmpNumAsync(string site, string empNum, CancellationToken ct = default)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Site == site && e.Emp_num == empNum, ct);
        }

        public async Task<IEnumerable<UserEntities>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
        {
            IQueryable<UserEntities> query = _context.Users.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.Emp_num.Contains(search) ||
                    (e.Name != null && e.Name.Contains(search)));
            }

            int validPage = page < 1 ? 1 : page;
            int validSize = pageSize < 1 ? 10 : pageSize;

            var items = await query
                .OrderBy(e => e.Id)
                .ToListAsync(ct);

            return items
                .Skip((validPage - 1) * validSize)
                .Take(validSize)
                .ToList();
        }

        public async Task AddAsync(UserEntities employee, CancellationToken ct = default)
        {
            await _context.Users.AddAsync(employee, ct);
        }

        public void Update(UserEntities employee)
        {
            _context.Users.Update(employee);
        }

        public void Remove(UserEntities employee)
        {
            _context.Users.Remove(employee);
        }

    }
}
