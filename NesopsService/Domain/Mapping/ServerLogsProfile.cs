using System;
using AutoMapper;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Mapping
{
    public partial class ServerLogsProfile
        : AutoMapper.Profile
    {
        public ServerLogsProfile()
        {
            CreateMap<NesopsService.Data.Entities.ServerLogs, NesopsService.Domain.Models.ServerLogsReadModel>();
            CreateMap<NesopsService.Domain.Models.ServerLogsCreateModel, NesopsService.Data.Entities.ServerLogs>();
            CreateMap<NesopsService.Data.Entities.ServerLogs, NesopsService.Domain.Models.ServerLogsUpdateModel>();
            CreateMap<NesopsService.Domain.Models.ServerLogsUpdateModel, NesopsService.Data.Entities.ServerLogs>();
        }

    }
}
