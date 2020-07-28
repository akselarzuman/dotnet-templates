using Aksel.AutomapperMappings;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.Api.Setups
{
    public class AutoMapperSetup : ISetup
    {
        public void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(typeof(AkselMapping));
        }
    }
}