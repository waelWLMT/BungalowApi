using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WLMT.Bungalows.Domain.Interfaces;
using WLMT.Bungalows.Infrastructure.Persistence;

namespace WLMT.Bungalows.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
        }

        public async Task DeleteAsync(T entity, CancellationToken ct = default)
        {
            await Task.Run(() => _dbSet.Update(entity), ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _context.SaveChangesAsync(ct);
        }

        public async Task RollBackAsync(CancellationToken ct = default)
        {
            await _context.DisposeAsync();
        }

        public async Task UpdateAsync(T entity, CancellationToken ct = default)
        {
            await Task.Run(() => _dbSet.Update(entity), ct);
        }
    }
}
