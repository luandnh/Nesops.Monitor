using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Queries
{
    public static partial class ServersExtensions
    {
        #region Generated Extensions
        public static NesopsService.Data.Entities.Servers GetByKey(this IQueryable<NesopsService.Data.Entities.Servers> queryable, Guid id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.Servers> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<NesopsService.Data.Entities.Servers> GetByKeyAsync(this IQueryable<NesopsService.Data.Entities.Servers> queryable, Guid id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.Servers> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<NesopsService.Data.Entities.Servers>(task);
        }

        #endregion

    }
}
