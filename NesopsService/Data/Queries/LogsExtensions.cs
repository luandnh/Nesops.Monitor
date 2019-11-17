using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Queries
{
    public static partial class LogsExtensions
    {
        #region Generated Extensions
        public static NesopsService.Data.Entities.Logs GetByKey(this IQueryable<NesopsService.Data.Entities.Logs> queryable, Guid id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.Logs> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<NesopsService.Data.Entities.Logs> GetByKeyAsync(this IQueryable<NesopsService.Data.Entities.Logs> queryable, Guid id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.Logs> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<NesopsService.Data.Entities.Logs>(task);
        }

        #endregion

    }
}
