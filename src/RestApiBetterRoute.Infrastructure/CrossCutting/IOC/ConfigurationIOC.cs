using Autofac;
using AutoMapper;
using RestApiBetterRoute.Application;
using RestApiBetterRoute.Application.Interfaces;
using RestApiBetterRoute.Application.Mappers;
using RestApiBetterRoute.Domain.Core.Interfaces.Repositories;
using RestApiBetterRoute.Domain.Core.Interfaces.Services;
using RestApiBetterRoute.Domain.Services;
using RestApiBetterRoute.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceRoute>().As<IApplicationServiceRoute>();
            builder.RegisterType<ServiceRoute>().As<IServiceRoute>();
            builder.RegisterType<RepositoryRoute>().As<IRepositoryRoute>();
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingRoute());
                cfg.AddProfile(new ModelToDtoMappingRoute());

            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            #endregion IOC
        }
    }
}
