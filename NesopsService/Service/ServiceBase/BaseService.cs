using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NesopsService.Identifier;
using NesopsService.Service.BaseRepo;
using NesopsService.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NesopsService.Service.ServiceBase
{
    public interface IBaseService{
    }
    public interface IBaseService<TDBContext, TEntity, TReadModel, TCreateModel, TUpdateModel, TRequestModel> : IBaseService
        where TDBContext : DbContext
        where TRequestModel : class, IRequestModelBase
        where TEntity : class, IHaveIdentifier
        where TReadModel : class
        where TCreateModel : class
        where TUpdateModel : class
    {
        TDBContext _dataContext { get; }
        IMapper _mapper { get; }
        TReadModel FindById(Guid id);
        ValueTask<TReadModel> FindByIdAsync(Guid id);
        ValueTask<TReadModel> FindByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
        ValueTask<TReadModel> FindByIdAsync(Guid id, TRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken));
        IQueryable<TEntity> GetAllAsNoTracking();
        IQueryable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TReadModel> GetAll();
        IEnumerable<TReadModel> Get(Expression<Func<TEntity, bool>> predicate);
        ValueTask<IEnumerable<TReadModel>> GetAllAsync();
        ValueTask<IEnumerable<TReadModel>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        ValueTask<IEnumerable<TReadModel>> GetAllAsync(TRequestModel requestMode, CancellationToken cancellationToken = default(CancellationToken));
        TReadModel FirstOrDefault();
        TReadModel FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TReadModel> FirstOrDefaultAsync();
        ValueTask<TReadModel> FirstOrDefaultAsync(CancellationToken cancellationToken = default(CancellationToken));
        ValueTask<TReadModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TReadModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
        TReadModel LastOrDefault();
        TReadModel LastOrDefault(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TReadModel> LastOrDefaultAsync();
        ValueTask<TReadModel> LastOrDefaultAsync(CancellationToken cancellationToken = default(CancellationToken));
        ValueTask<TReadModel> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TReadModel> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
        TReadModel Create(TCreateModel createModel);
        ValueTask<TReadModel> CreateAsync(TCreateModel createModel);
        ValueTask<TReadModel> CreateAsync(TCreateModel createModel, CancellationToken cancellationToken = default(CancellationToken));
        void Delete(TReadModel readModel);
        void Delete<TKey>(TKey id);
        ValueTask DeleteAsync<TKey>(TKey id);
        ValueTask DeleteAsync<TKey>(TKey id, CancellationToken cancellationToken = default(CancellationToken));
        ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        TReadModel Update(TUpdateModel updateModel);
        ValueTask<TReadModel> UpdateAsync(TUpdateModel updateModel);
        ValueTask<TReadModel> UpdateAsync(TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken));
        TReadModel Update<TKey>(TKey id, TUpdateModel updateModel);
        ValueTask<TReadModel> UpdateAsync<TKey>(TKey id, TUpdateModel updateModel);
        ValueTask<TReadModel> UpdateAsync<TKey>(TKey id, TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken));

    }
    public class BaseService<TDBContext, TEntity, TReadModel, TCreateModel, TUpdateModel, TRequestModel> : IBaseService<TDBContext, TEntity, TReadModel, TCreateModel, TUpdateModel, TRequestModel>
        where TDBContext : DbContext
        where TRequestModel : class, IRequestModelBase
        where TEntity : class, IHaveIdentifier
        where TReadModel : class
        where TCreateModel : class
        where TUpdateModel : class
    {
        public TDBContext _dataContext { get; }
        public IMapper _mapper { get; }
        private IUnitOfWork<TDBContext> _uof;
        public BaseService(IUnitOfWork<TDBContext> unitOfWork, IMapper mapper)
        {
            this._uof = unitOfWork;
            this._dataContext = unitOfWork.DbContext;
            this._mapper = mapper;
        }

        public IUnitOfWork<TDBContext> _unitOfWork { get => _uof; }

        #region Handle TRequestModel
        public virtual IQueryable<TEntity> HandleRequest(TRequestModel request)
        {
            return _dataContext.Set<TEntity>().AsNoTracking();
        }
        #endregion
        #region Find Services
        public TReadModel FindById(Guid id)
        {
            var entity = _dataContext.Set<TEntity>().Find(id);
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> FindByIdAsync(Guid id)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> FindByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id, cancellationToken);
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> FindByIdAsync(Guid id,TRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = HandleRequest(requestModel);
            var entity = await query.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        #endregion
        #region As No Tracking Getter Utils
        public virtual IQueryable<TEntity> GetAllAsNoTracking()
        {
            return _dataContext.Set<TEntity>().AsNoTracking();
        }

        public virtual IQueryable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Set<TEntity>().Where(predicate);
        }

        #endregion
        #region Get Services
        public virtual IEnumerable<TReadModel> GetAll()
        {
            var result = _mapper.Map<List<TReadModel>>((GetAllAsNoTracking().ToList()));
            return result;
        }

        public virtual IEnumerable<TReadModel> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _mapper.Map<List<TReadModel>>((GetAsNoTracking(predicate).ToList()));
            return result;
        }
        public virtual async ValueTask<IEnumerable<TReadModel>> GetAllAsync()
        {
            var result = _mapper.Map<List<TReadModel>>((await GetAllAsNoTracking().ToListAsync()));
            return result;
        }
        public virtual async ValueTask<IEnumerable<TReadModel>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = _mapper.Map<List<TReadModel>>((await GetAllAsNoTracking().ToListAsync(cancellationToken)));
            return result;
        }
        public virtual async ValueTask<IEnumerable<TReadModel>> GetAllAsync(TRequestModel requestModel,CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = HandleRequest(requestModel);
            var result = _mapper.Map<List<TReadModel>>((await query.ToListAsync(cancellationToken)));
            return result;
        }
        #endregion
        #region First or Default Services
        public TReadModel FirstOrDefault()
        {
            var entity = GetAllAsNoTracking().FirstOrDefault();
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public TReadModel FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = GetAsNoTracking(predicate).FirstOrDefault();
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> FirstOrDefaultAsync()
        {
            var entity = await GetAllAsNoTracking().FirstOrDefaultAsync();
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> FirstOrDefaultAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await GetAllAsNoTracking().FirstOrDefaultAsync(cancellationToken);
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await GetAsNoTracking(predicate).FirstOrDefaultAsync();
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await GetAsNoTracking(predicate).FirstOrDefaultAsync(cancellationToken);
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }

        #endregion
        #region Last or Default Services
        public TReadModel LastOrDefault()
        {
            var entity = GetAllAsNoTracking().LastOrDefault();
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public TReadModel LastOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = GetAsNoTracking(predicate).LastOrDefault();
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> LastOrDefaultAsync()
        {
            var entity = await GetAllAsNoTracking().LastOrDefaultAsync();
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> LastOrDefaultAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await GetAllAsNoTracking().LastOrDefaultAsync(cancellationToken);
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await GetAsNoTracking(predicate).LastOrDefaultAsync();
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }
        public async ValueTask<TReadModel> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await GetAsNoTracking(predicate).LastOrDefaultAsync(cancellationToken);
            var result = _mapper.Map<TReadModel>(entity);
            return result;
        }

        #endregion
        #region Create Services
        public TReadModel Create(TCreateModel createModel)
        {
            // create new entity from model
            var entity = _mapper.Map<TEntity>(createModel);
            var result = _dataContext
                .Set<TEntity>().Add(entity);
            _dataContext.SaveChanges();
            return _mapper.Map<TReadModel>(result.Entity);
        }
        public async ValueTask<TReadModel> CreateAsync(TCreateModel createModel)
        {
            // create new entity from model
            var entity = _mapper.Map<TEntity>(createModel);
            var result = await _dataContext
                .Set<TEntity>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<TReadModel>(result.Entity);
        }
        public async ValueTask<TReadModel> CreateAsync(TCreateModel createModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create new entity from model
            var entity = _mapper.Map<TEntity>(createModel);
            var result = await _dataContext
                .Set<TEntity>().AddAsync(entity,cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TReadModel>(result.Entity);
        }
        #endregion
        #region Delete Services
        public void Delete(TReadModel readModel)
        {
            var entity = _mapper.Map<TEntity>(readModel);
            _dataContext.Set<TEntity>().Remove(entity);
            _dataContext.SaveChanges();
        }
        public void Delete<TKey>(TKey id)
        {
            var entity = _dataContext.Set<TEntity>().Find(id);
            _dataContext.Set<TEntity>().Remove(entity);
            _dataContext.SaveChanges();
        }
        public async ValueTask DeleteAsync<TKey>(TKey id)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);
            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
        public async ValueTask DeleteAsync<TKey>(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);
            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
        public async ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
        #endregion
        #region Update Services
        public TReadModel Update(TUpdateModel updateModel)
        {
            var entity = _mapper.Map<TEntity>(updateModel);
            var result = _dataContext.Set<TEntity>().Update(entity);
            _dataContext.SaveChanges();
            return _mapper.Map<TReadModel>(result.Entity);
        }
        public async ValueTask<TReadModel> UpdateAsync(TUpdateModel updateModel)
        {
            var entity = _mapper.Map<TEntity>(updateModel);
            var result = _dataContext.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<TReadModel>(result.Entity);
        }
        public async ValueTask<TReadModel> UpdateAsync(TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = _mapper.Map<TEntity>(updateModel);
            var result = _dataContext.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TReadModel>(result.Entity);
        }
        public TReadModel Update<TKey>(TKey id, TUpdateModel updateModel)
        {
            var entity = _dataContext.Set<TEntity>().Find(id);
            entity = _mapper.Map<TUpdateModel, TEntity>(updateModel);
            var result = _dataContext.Set<TEntity>().Update(entity);
            _dataContext.SaveChanges();
            return _mapper.Map<TReadModel>(result.Entity);
        }
        public async ValueTask<TReadModel> UpdateAsync<TKey>(TKey id, TUpdateModel updateModel)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);
            entity = _mapper.Map<TEntity>(updateModel);
            var result = _dataContext.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<TReadModel>(result.Entity);
        }
        public async ValueTask<TReadModel> UpdateAsync<TKey>(TKey id, TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id,cancellationToken);
            entity = _mapper.Map<TEntity>(updateModel);
            var result = _dataContext.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TReadModel>(result.Entity);
        }
        //public async Task<TViewModel> DeactiveAsync<TKey>(TKey id)
        //{
        //    var entity = await selfDbSet.FindAsync(id);
        //    if (typeof(IActivable).IsAssignableFrom(typeof(TEntity)))
        //    {
        //        ((IActivable)entity).Active = false;
        //    }
        //    selfDbSet.Update(entity);
        //    await dbContext.SaveChangesAsync();
        //    return CreateVM(entity);

        //}
        #endregion
    }
}
