using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace NesopsService.Service.BaseRepo
{
    public interface IUnitOfWork : IUnitOfWork<DbContext>
    {
        #region Unit Of Work features

        #endregion
    }
    public class UnitOfWork : UnitOfWork<DbContext>, IUnitOfWork, IDisposable
    {
        public UnitOfWork(DbContext dbContext) : base(dbContext)
        {
        }
    }
    public interface IUnitOfWork<TDBContext> : IDisposable
    where TDBContext : DbContext
    {
        #region Unit Of Work features
        TDBContext DbContext { get; }
        void Commit();
        IDbContextTransaction CreateTransac();
        #endregion
    }

    /// <summary>
    /// Unit Of Work
    /// </summary>

    public class UnitOfWork<TDBContext> : IUnitOfWork<TDBContext>, IDisposable
        where TDBContext : DbContext
    {
        private TDBContext _dbContext;
        public UnitOfWork(TDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Unit Of Work features
        private bool _disposed = false;
        public TDBContext DbContext { get => _dbContext; }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public IDbContextTransaction CreateTransac()
        {
            var transaction = _dbContext.Database.BeginTransaction();
            return transaction;
        }
        #endregion

    }
}
