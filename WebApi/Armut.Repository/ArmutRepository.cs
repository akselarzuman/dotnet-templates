using System.Threading.Tasks;
using Armut.Models.Entities;
using Armut.Repository.Contracts;

namespace Armut.Repository
{
    public class ArmutRepository : IArmutRepository
    {
        public async Task<ArmutEntity> GetAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}