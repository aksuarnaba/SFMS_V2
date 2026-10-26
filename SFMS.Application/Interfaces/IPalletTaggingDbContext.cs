using Microsoft.EntityFrameworkCore;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Interfaces
{
    public interface IPalletTaggingDbContext
    {
        DbSet<EmployeeEntities> Employees { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
