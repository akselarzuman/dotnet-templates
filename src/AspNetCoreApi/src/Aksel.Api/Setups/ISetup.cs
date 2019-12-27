using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.Api.Setups
{
    public interface ISetup
    {
        public void Configure(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}