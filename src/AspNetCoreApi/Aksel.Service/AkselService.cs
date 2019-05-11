using System.Threading.Tasks;
using Aksel.Models.Entities;
using Aksel.Models.Models;
using Aksel.Repository.Contracts;
using Aksel.Service.Contracts;
using AutoMapper;

namespace Aksel.Service
{
    public class AkselService : IAkselService
    {
        private readonly IAkselRepository _AkselRepository;

        public AkselService(IAkselRepository AkselRepository)
        {
            _AkselRepository = AkselRepository;
        }

        public async Task<AkselModel> AddAsync(AkselModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AkselModel> GetAsync()
        {
            AkselEntity AkselEntity = await _AkselRepository.GetAsync();
            AkselModel AkselModel = Mapper.Map<AkselModel>(AkselEntity);

            return AkselModel;
        }
    }
}