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
    public class AuditLogService : BaseService<NesopsMonitorContext, AuditLogs, AuditLogsReadModel, AuditLogsCreateModel, AuditLogsUpdateModel, AuditLogRequestModel>
    {
        public AuditLogService(IUnitOfWork<NesopsMonitorContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
