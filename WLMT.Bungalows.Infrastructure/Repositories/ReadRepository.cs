using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WLMT.Bungalows.Domain.Interfaces;
using WLMT.Bungalows.Infrastructure.Persistence;

namespace WLMT.Bungalows.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly IQueryable<T> _dbSet;
        public ReadRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> AsQueryable()
        {
            return _dbSet;
        }
        public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet.FirstAsync(e => EF.Property<int>(e, "Id") == id, ct);
        }
        public async Task<IEnumerable<T>> ListAsync(CancellationToken ct = default)
        {
           return await _dbSet.ToListAsync(ct);
        }
        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default,   params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            
            if(predicate != null)
                query = query.Where(predicate);

            foreach(var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync(ct);


        }
    }
}
