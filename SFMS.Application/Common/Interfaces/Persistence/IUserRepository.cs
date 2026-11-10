using SFMS.Domain.Entities;
using SFMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetByEmployeeNumberAsync(SiteEnums site, string EmployeeNumber, CancellationToken ct = default);
        Task<(IReadOnlyList<User> Users, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default);
    }
}
