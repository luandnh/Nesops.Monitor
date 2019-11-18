using System;
using AutoMapper;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Mapping
{
    public partial class AuditLogsProfile
        : AutoMapper.Profile
    {
        public AuditLogsProfile()
        {
            CreateMap<NesopsService.Data.Entities.AuditLogs, NesopsService.Domain.Models.AuditLogsReadModel>();
            CreateMap<NesopsService.Domain.Models.AuditLogsCreateModel, NesopsService.Data.Entities.AuditLogs>();
            CreateMap<NesopsService.Data.Entities.AuditLogs, NesopsService.Domain.Models.AuditLogsUpdateModel>();
            CreateMap<NesopsService.Domain.Models.AuditLogsUpdateModel, NesopsService.Data.Entities.AuditLogs>();
        }

    }
}
