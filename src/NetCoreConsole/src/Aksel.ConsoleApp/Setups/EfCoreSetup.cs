using Aksel.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.ConsoleApp.Setups
{
    public class EfCoreSetup : ISetup
    {
        public void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AkselDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("AkselDbConnectionString")));
        }
    }
}