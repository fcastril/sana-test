using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Sana.Backend.Domain.Port.Base
{
    public partial interface IMainContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int ExecuteQuery(string sQuery);
        Task<int> ExecuteQueryAsync(string sQuery);
    }
}
