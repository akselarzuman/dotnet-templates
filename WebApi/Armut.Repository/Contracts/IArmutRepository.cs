using Armut.Models.Entities;

namespace Armut.Repository.Contracts
{
    public interface IArmutRepository
    {
        ArmutEntity Get();
    }
}