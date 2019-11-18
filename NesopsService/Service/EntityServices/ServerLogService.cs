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

namespace NesopsService.Service.EntityServices
{
    public class ServerLogService : BaseService<NesopsMonitorContext, ServerLogs, ServerLogsReadModel, ServerLogsCreateModel, ServerLogsUpdateModel, ServerLogRequestModel>
    {
        public ServerLogService(IUnitOfWork<NesopsMonitorContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
