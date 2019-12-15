using System.Threading.Tasks;
using Aksel.Models.Models;

namespace Aksel.Service.Contracts
{
    public interface ILoginService : IService
    {
        Task<string> LoginAsync(string email, string password);
    }
}