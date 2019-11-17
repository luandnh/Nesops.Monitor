using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NesopsService.Data;
using NesopsService.Identifier;
using NesopsService.Service.Models;
using NesopsService.Service.Models.ResponseModels;
using NesopsService.Service.ServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace NesopsService.EntityControllerBase
{
    public interface IEntityControllerBase<TReadModel, TCreateModel, TUpdateModel, TRequestModel>
        where TRequestModel : class, IRequestModelBase
        where TReadModel : class
        where TCreateModel : class
        where TUpdateModel : class
    {
        Task<ActionResult<GetResponseModel<TReadModel, TRequestModel>>> Get(Guid id, [FromQuery] TRequestModel requestModel, CancellationToken cancellationToken);
        Task<ActionResult<GetResponseModel<TReadModel, TRequestModel>>> List([FromQuery] TRequestModel requestModel, CancellationToken cancellationToken);
    }
    [ApiController]
    [Produces("application/json")]
    public abstract class EntityControllerBase<TDBContext, TEntity, TReadModel, TCreateModel, TUpdateModel, TRequestModel, TService> : ControllerBase
        where TDBContext : DbContext    
        where TEntity : class, IHaveIdentifier
        where TRequestModel : class, IRequestModelBase
        where TReadModel : class
        where TCreateModel : class
        where TUpdateModel : class
        where TService : class, IBaseService<TDBContext, TEntity, TReadModel, TCreateModel, TUpdateModel, TRequestModel>
    {
        protected TDBContext _dataContext { get; }
        protected IMapper _mapper { get; }
        protected TService _service { get; set; }

        protected EntityControllerBase(TDBContext dataContext, IMapper mapper, TService service)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
            this._service = service;
        }
        protected virtual async Task<GetResponseModel<TReadModel,TRequestModel>> ReadModel(Guid id, TRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var readModel = await _service.FindByIdAsync(id, requestModel, cancellationToken);
            if (readModel == null)
            {
                return null;
            }
            var result = new GetResponseModel<TReadModel, TRequestModel>(readModel);
            return result;
        }
        protected virtual async Task<GetResponseModel<TReadModel, TRequestModel>> ListModel(TRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var readModel = (await _service.GetAllAsync(requestModel,cancellationToken)).ToList();
            if (readModel == null)
            {
                return null;
            }
            var result = new GetResponseModel<TReadModel, TRequestModel>(readModel, requestModel);
            return result;
        }
         protected virtual async Task<TReadModel> CreateModel(TCreateModel createModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _service.CreateAsync(createModel, cancellationToken);
            return result;
        }

        protected virtual async Task<TReadModel> UpdateModel(Guid id, TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = _service.FindById(id);
            if (entity == null)
            {
                return default;
            }
            var result = await _service.UpdateAsync(id,updateModel,cancellationToken);
            return result;
        }

        protected virtual async Task<TReadModel> DeleteModel(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = _service.FindById(id);
            if (entity == null)
                return default(TReadModel) ;

            // return read model
            var readModel = await ReadModel(id, cancellationToken);
            await _service.DeleteAsync<Guid>(id, cancellationToken);
            return readModel;
        }
        private async Task<TReadModel> ReadModel(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var model = await _dataContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(p => p.Id == id)
                .ProjectTo<TReadModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return model;
        }
    }
}
