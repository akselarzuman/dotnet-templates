using System;
using System.IO;
using Aksel.Repository;
using Aksel.Repository.Context;
using Aksel.Repository.Contracts;
using Aksel.Service;
using Aksel.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.ConsoleApp
{
    public class DependencyFactory
    {
        private static readonly IConfigurationRoot _configuration;
        private static readonly IServiceCollection _services;
        private ServiceProvider _serviceProvider;

        public static readonly DependencyFactory Instance = new DependencyFactory();

        private DependencyFactory() { }

        static DependencyFactory()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);


            _configuration = builder.Build();
            _services = new ServiceCollection();
        }

        public void RegisterDependencies()
        {
            AutoMapperConfiguration.Initialize();

            _services
                .AddTransient<IAkselRepository, AkselRepository>()
                .AddTransient<IAkselService, AkselService>();

            _services.AddDbContext<AkselDbContext>(o => o.UseSqlServer(_configuration.GetConnectionString("AkselDbConnectionString")));

            _serviceProvider = _services.BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}