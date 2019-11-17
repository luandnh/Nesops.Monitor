using System;
using AutoMapper;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Mapping
{
    public partial class ServersProfile
        : AutoMapper.Profile
    {
        public ServersProfile()
        {
            CreateMap<NesopsService.Data.Entities.Servers, NesopsService.Domain.Models.ServersReadModel>();
            CreateMap<NesopsService.Domain.Models.ServersCreateModel, NesopsService.Data.Entities.Servers>();
            CreateMap<NesopsService.Data.Entities.Servers, NesopsService.Domain.Models.ServersUpdateModel>();
            CreateMap<NesopsService.Domain.Models.ServersUpdateModel, NesopsService.Data.Entities.Servers>();
        }

    }
}
