using System.Threading.Tasks;
using Armut.Models.Entities;
using Armut.Models.Models;
using Armut.Repository.Contracts;
using Armut.Service.Contracts;
using AutoMapper;

namespace Armut.Service
{
    public class ArmutService : IArmutService
    {
        private readonly IArmutRepository _armutRepository;

        public ArmutService(IArmutRepository armutRepository)
        {
            _armutRepository = armutRepository;
        }

        public async Task<ArmutModel> GetAsync()
        {
            ArmutEntity armutEntity = await _armutRepository.GetAsync();
            ArmutModel armutModel = Mapper.Map<ArmutModel>(armutEntity);

            return armutModel;
        }
    }
}