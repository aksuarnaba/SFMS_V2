using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntities?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<UserEntities?> GetByEmpNumAsync(string site, string empNum, CancellationToken ct = default);
        Task<IEnumerable<UserEntities>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task AddAsync(UserEntities employee, CancellationToken ct = default);
        void Update(UserEntities employee);
        void Remove(UserEntities employee);
    }
}
