using System.Threading.Tasks;
using Aksel.Models.Models;

namespace Aksel.Service.Contracts
{
    public interface IAkselService
    {
        Task<AkselModel> GetAsync(long id);
        
        Task<AkselModel> AddAsync(AkselModel model);

        Task DeleteAsync(long id);

        Task UpdateAsync(AkselModel model);
    }
}