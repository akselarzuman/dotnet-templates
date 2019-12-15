using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.ConsoleApp.Setups
{
    public interface ISetup
    {
        public void Configure(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}