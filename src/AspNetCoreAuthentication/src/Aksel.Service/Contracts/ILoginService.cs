using System.Threading.Tasks;
using Aksel.Models.Models;

namespace Aksel.Service.Contracts
{
    public interface ILoginService
    {
        Task<string> LoginAsync(string email, string password);
    }
}