﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using LilySimple.Services;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using AutofacModule = Autofac.Module;

namespace LilySimple.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IApplicationBuilder UseIocManager(this IApplicationBuilder app)
        {
            Autofac.IocManager.Instance.ServiceProvider = app.ApplicationServices.GetAutofacRoot();

            return app;
        }
    }

    public class ApplicationModule : AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var assemblies = ReflectionHelper.GetAllAssemblies();

            //builder.RegisterAssemblyTypes(assemblies.ToArray())
            //    .Where(t => typeof(ServiceBase).IsAssignableFrom(t) && !t.IsAbstract)
            //    .AsSelf()
            //    .InstancePerLifetimeScope(); 

            var servicesTypesInAssembly = typeof(ServiceBase).Assembly.GetExportedTypes()
                .Where(type => typeof(ServiceBase).IsAssignableFrom(type)).ToArray();

            builder.RegisterTypes(servicesTypesInAssembly).PropertiesAutowired();
        }
    }
}
