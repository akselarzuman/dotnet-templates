using System.Threading.Tasks;
using Armut.Models.Entities;

namespace Armut.Repository.Contracts
{
    public interface IArmutRepository
    {
        Task<ArmutEntity> GetAsync();
    }
}