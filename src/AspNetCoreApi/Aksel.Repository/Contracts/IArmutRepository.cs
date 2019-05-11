using System.Threading.Tasks;
using Aksel.Models.Entities;

namespace Aksel.Repository.Contracts
{
    public interface IAkselRepository
    {
        Task<AkselEntity> GetAsync();
    }
}