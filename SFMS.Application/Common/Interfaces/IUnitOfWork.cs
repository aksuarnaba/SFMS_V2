using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
