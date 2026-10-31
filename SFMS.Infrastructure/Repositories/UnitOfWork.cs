using SFMS.Application.Common.Interfaces;
using SFMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PalletTaggingDbContext _context;
        public UnitOfWork(
            PalletTaggingDbContext context,
            IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
        }
        public IUserRepository Users { get; }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
