using System.Threading.Tasks;
using Aksel.Models.Models;

namespace Aksel.Service.Contracts
{
    public interface IAkselService
    {
        Task<AkselModel> GetAsync();
        
        Task<AkselModel> AddAsync(AkselModel model);
    }
}