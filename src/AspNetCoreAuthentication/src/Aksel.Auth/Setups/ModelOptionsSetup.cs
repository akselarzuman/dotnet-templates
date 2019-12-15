using Aksel.Models.Models.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.Auth.Setups
{
    public class ModelOptionsSetup : ISetup
    {
        public void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<AudienceModel>(configuration.GetSection("Audience"));
        }
    }
}