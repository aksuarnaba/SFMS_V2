using Microsoft.EntityFrameworkCore;
using SFMS.Application.Common.Interfaces;
using SFMS.Domain.Entities;
using SFMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PalletTaggingDbContext _context;


        public EmployeeRepository(PalletTaggingDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeEntities?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id, ct);
        }

        public async Task<EmployeeEntities?> GetByEmpNumAsync(string site, string empNum, CancellationToken ct = default)
        {
            return await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Site == site && e.Emp_num == empNum, ct);
        }

        public async Task<IEnumerable<EmployeeEntities>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
        {
            IQueryable<EmployeeEntities> query = _context.Employees.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                e.Emp_num.Contains(search) ||
                (e.Name != null && e.Name.Contains(search)));
            }

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task AddAsync(EmployeeEntities employee)
        {
            await _context.Employees.AddAsync(employee);
            
        }

        public void Update(EmployeeEntities employee)
        {
            _context.Employees.Update(employee);
        }

        public void Remove(EmployeeEntities employee)
        {
            _context.Employees.Remove(employee);
        }

    }
}
