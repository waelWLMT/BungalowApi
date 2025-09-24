using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLMT.Bungalows.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(T entity, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
        Task RollBackAsync(CancellationToken ct = default);
    }
}
