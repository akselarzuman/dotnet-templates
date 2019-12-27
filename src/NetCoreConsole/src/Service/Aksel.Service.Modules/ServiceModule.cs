using System;
using System.Collections.Generic;
using System.Linq;
using Aksel.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.Service.Module
{
    public static class ServiceModule
    {
        public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services)
        {
            List<Type> types = typeof(AkselService).Assembly.GetTypes()
                                                .Where(m => typeof(IService).IsAssignableFrom(m) && !m.IsInterface && !m.IsAbstract)
                                                .ToList();

            foreach (Type type in types)
            {
                Type serviceInterfaceType = type.GetInterfaces()
                                                .FirstOrDefault(interfaceType => interfaceType.GetInterfaces().Contains(typeof(IService))
                                                                     && interfaceType.GetInterfaces().Length == 1);

                services.AddTransient(serviceInterfaceType, type);
            }

            return services;
        }
    }
}