using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pegov.Nasvyazi.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<T> Set<T>()
            where T : class;

        DbContext DbContext { get; }
        DbConnection DbConnection { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> ExecuteSqlRawAsync(string sql, CancellationToken token = default);
    }
}