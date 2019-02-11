using System.Threading.Tasks;
using Armut.Models.Models;

namespace Armut.Service.Contracts
{
    public interface IArmutService
    {
        Task<ArmutModel> GetAsync();
    }
}