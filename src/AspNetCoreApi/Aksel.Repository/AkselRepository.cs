using System.Threading.Tasks;
using Aksel.Models.Entities;
using Aksel.Repository.Contracts;

namespace Aksel.Repository
{
    public class AkselRepository : IAkselRepository
    {
        public async Task<AkselEntity> GetAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}