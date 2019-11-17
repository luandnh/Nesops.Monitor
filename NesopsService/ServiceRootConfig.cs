using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NesopsService.Data;
using NesopsService.Data.Entities;
using NesopsService.Domain.Mapping;
using NesopsService.Domain.Models;
using NesopsService.Domain.Validation;
using NesopsService.Service.BaseRepo;
using NesopsService.Service.ServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NesopsService
{
    public static class ServiceRootConfig
    {
        public static void Entry(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(DbContext), typeof(NesopsMonitorContext));
            services.AddScoped(typeof(IUnitOfWork<NesopsMonitorContext>), typeof(UnitOfWork<NesopsMonitorContext>));
            #region Auto Mapper Config
            // register AutoMapper profiles
            //services.AddAutoMapper(typeof(AspNetUsersProfile));
            services.AddAutoMapper(typeof(ApplicationsProfile).GetTypeInfo().Assembly);
            #endregion
            #region Config Validator
            // FluentValidation read on class extend AbstractValidator
            var types = typeof(ApplicationsCreateModelValidator).Assembly.GetTypes();
            new AssemblyScanner(types).ForEach(pair => {
                services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
            });
            #endregion
            var typeService = typeof(IBaseService);
            var typesService = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => typeService.IsAssignableFrom(p));
            foreach (Type type in typesService)
            {
                if (!type.Name.Contains("BaseService"))
                {
                    services.AddScoped(type);
                    System.Diagnostics.Debug.WriteLine(type.Name);
                }

            }
        }
    }
}
