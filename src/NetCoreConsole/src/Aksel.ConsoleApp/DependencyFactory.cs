using System;
using System.IO;
using Aksel.ConsoleApp.Setups;
using Aksel.ModelValidators.Module;
using Aksel.Repository.Module;
using Aksel.Service.Module;
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
            _services.ConfigureServices(_configuration);

            _services
                .RegisterModelValidatorDependencies()
                .RegisterRepositoryDependencies()
                .RegisterServiceDependencies();

            _serviceProvider = _services.BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}