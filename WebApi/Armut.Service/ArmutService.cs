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

        public ArmutModel Get()
        {
            ArmutEntity armutEntity = _armutRepository.Get();
            ArmutModel armutModel = Mapper.Map<ArmutModel>(armutEntity);

            return armutModel;
        }
    }
}