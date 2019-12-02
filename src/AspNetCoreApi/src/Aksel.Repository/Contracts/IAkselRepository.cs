using System.Threading.Tasks;
using Aksel.Models.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aksel.Repository.Contracts
{
    public interface IAkselRepository : IRepository
    {
        ValueTask<EntityEntry<AkselEntity>> AddAsync(AkselEntity entity);
        
        Task<AkselEntity> GetAsync(long id);

        EntityEntry<AkselEntity> Update(AkselEntity entity);
    }
}