using Aksel.Repository.Context;
using Aksel.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aksel.Repository.Module
{
    public static class RepositoryModule
    {
        public static IServiceCollection RegisterRepositoryDependencies(this IServiceCollection services)
        {
            List<Type> types = typeof(AkselRepository).Assembly.GetTypes()
                                                .Where(m => typeof(IRepository).IsAssignableFrom(m) && !m.IsInterface && !m.IsAbstract)
                                                .ToList();

            foreach (Type type in types)
            {
                Type serviceInterfaceType = type.GetInterfaces()
                                                .FirstOrDefault(interfaceType => interfaceType.GetInterfaces().Contains(typeof(IRepository))
                                                                     && interfaceType.GetInterfaces().Length == 1);

                services.AddTransient(serviceInterfaceType, type);
            }

            return services;
        }
    }
}