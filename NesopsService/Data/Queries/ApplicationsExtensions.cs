using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Queries
{
    public static partial class ApplicationsExtensions
    {
        #region Generated Extensions
        public static NesopsService.Data.Entities.Applications GetByKey(this IQueryable<NesopsService.Data.Entities.Applications> queryable, Guid id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.Applications> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<NesopsService.Data.Entities.Applications> GetByKeyAsync(this IQueryable<NesopsService.Data.Entities.Applications> queryable, Guid id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.Applications> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<NesopsService.Data.Entities.Applications>(task);
        }

        #endregion

    }
}
