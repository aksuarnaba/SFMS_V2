using Microsoft.EntityFrameworkCore;
using SFMS.Application.Common.Interfaces;
using SFMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {

        private readonly PalletTaggingDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(PalletTaggingDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<T?> GetByIdAsync(object id, CancellationToken ct = default)
        {
            return await _context.Set<T>().FindAsync(new[] { id }, ct);

        }

        public async Task AddAsync(T entity, CancellationToken ct = default)
        {
            await _context.Set<T>().AddAsync(entity, ct);
        }

        public async Task<int> CommitAsync(CancellationToken ct = default)
        {
            return await _unitOfWork.SaveChangesAsync(ct);
        }
    }
}
