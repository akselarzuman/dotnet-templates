using System;
using System.Threading.Tasks;
using Aksel.Service.Contracts;

namespace Aksel.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DependencyFactory.Instance.RegisterDependencies();
            IAkselService AkselService = DependencyFactory.Instance.Resolve<IAkselService>();
            
            await Console.Out.WriteLineAsync("Hello World!");
        }
    }
}
