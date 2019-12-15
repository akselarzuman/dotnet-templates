using System.Threading.Tasks;
using Aksel.Repository.Entities;

namespace Aksel.Repository.Contracts
{
    public interface IAkselRepository : IRepository
    {
        Task<AkselEntity> AddAsync(AkselEntity entity);
        
        Task<AkselEntity> GetAsync(long id);

        Task UpdateAsync(AkselEntity entity);
    }
}