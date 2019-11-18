using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Queries
{
    public static partial class ServerLogsExtensions
    {
        #region Generated Extensions
        public static NesopsService.Data.Entities.ServerLogs GetByKey(this IQueryable<NesopsService.Data.Entities.ServerLogs> queryable, Guid id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.ServerLogs> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<NesopsService.Data.Entities.ServerLogs> GetByKeyAsync(this IQueryable<NesopsService.Data.Entities.ServerLogs> queryable, Guid id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.ServerLogs> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<NesopsService.Data.Entities.ServerLogs>(task);
        }

        #endregion

    }
}
