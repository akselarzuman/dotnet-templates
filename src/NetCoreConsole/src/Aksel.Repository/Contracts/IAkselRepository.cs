using System.Threading.Tasks;
using Aksel.Models.Entities;

namespace Aksel.Repository.Contracts
{
    public interface IAkselRepository
    {
        Task<AkselEntity> AddAsync(AkselEntity entity);
        
        Task<AkselEntity> GetAsync(long id);

        Task UpdateAsync(AkselEntity entity);
    }
}