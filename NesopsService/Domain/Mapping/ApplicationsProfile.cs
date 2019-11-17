using System;
using AutoMapper;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Mapping
{
    public partial class ApplicationsProfile
        : AutoMapper.Profile
    {
        public ApplicationsProfile()
        {
            CreateMap<NesopsService.Data.Entities.Applications, NesopsService.Domain.Models.ApplicationsReadModel>();
            CreateMap<NesopsService.Domain.Models.ApplicationsCreateModel, NesopsService.Data.Entities.Applications>();
            CreateMap<NesopsService.Data.Entities.Applications, NesopsService.Domain.Models.ApplicationsUpdateModel>();
            CreateMap<NesopsService.Domain.Models.ApplicationsUpdateModel, NesopsService.Data.Entities.Applications>();
        }

    }
}
