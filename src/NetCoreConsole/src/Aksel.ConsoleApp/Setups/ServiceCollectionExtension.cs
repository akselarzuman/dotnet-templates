using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.ConsoleApp.Setups
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            List<ISetup> installers = typeof(DependencyFactory).Assembly.ExportedTypes
                .Where(m => typeof(ISetup).IsAssignableFrom(m) && !m.IsInterface && !m.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<ISetup>()
                .ToList();

            installers.ForEach(m => m.Configure(serviceCollection, configuration));
        }
    }
}