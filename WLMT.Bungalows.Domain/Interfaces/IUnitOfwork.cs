using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLMT.Bungalows.Domain.Interfaces
{
    public interface IUnitOfwork
    {
        Task CommitAsync(CancellationToken ct);
        Task RollbackAsync(CancellationToken ct);

        void Commit();
        void Rollback();
    }
}
