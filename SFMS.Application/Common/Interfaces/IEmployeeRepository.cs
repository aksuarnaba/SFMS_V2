using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EmployeeEntities?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<EmployeeEntities?> GetByEmpNumAsync(string site, string empNum, CancellationToken ct = default);
        Task<IEnumerable<EmployeeEntities>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task AddAsync(EmployeeEntities employee);
        void Update(EmployeeEntities employee);
        void Remove(EmployeeEntities employee);
    }
}
