using System;
using AutoMapper;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Mapping
{
    public partial class LogsProfile
        : AutoMapper.Profile
    {
        public LogsProfile()
        {
            CreateMap<NesopsService.Data.Entities.Logs, NesopsService.Domain.Models.LogsReadModel>();
            CreateMap<NesopsService.Domain.Models.LogsCreateModel, NesopsService.Data.Entities.Logs>();
            CreateMap<NesopsService.Data.Entities.Logs, NesopsService.Domain.Models.LogsUpdateModel>();
            CreateMap<NesopsService.Domain.Models.LogsUpdateModel, NesopsService.Data.Entities.Logs>();
        }

    }
}
