using AutoMapper;
using NesopsService.Data;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;
using NesopsService.Service.BaseRepo;
using NesopsService.Service.Models.RequestModels;
using NesopsService.Service.ServiceBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NesopsService.Service.EntityServices
{
    public class LogService : BaseService<NesopsMonitorContext, Logs, LogsReadModel, LogsCreateModel, LogsUpdateModel, LogRequestModel>
    {
        public LogService(IUnitOfWork<NesopsMonitorContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        //public async ValueTask<LogsReadModel> Create(LogsCreateModel model, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    List<string> LogLevels = new List<string> { "Information", "Warning", "Error" };
        //    if (!LogLevels.Contains(model.Level)) return null;
        //    var result = await CreateAsync(model, cancellationToken);
        //    return result;
        //}
    }
}
