using System;
using System.Threading.Tasks;
using Aksel.Repository.Entities;
using Aksel.Models.Models;
using Aksel.Repository.Contracts;
using Aksel.Service.Contracts;
using AutoMapper;
using Aksel.ModelValidators.FluentValidator;

namespace Aksel.Service
{
    public class AkselService : IAkselService
    {
        private readonly IAkselRepository _AkselRepository;
        private readonly IModelValidator _modelValidator;
        private readonly IMapper _mapper;

        public AkselService(
            IAkselRepository AkselRepository,
            IModelValidator modelValidator,
            IMapper mapper)
        {
            _AkselRepository = AkselRepository;
            _modelValidator = modelValidator;
            _mapper = mapper;
        }

        public async Task<AkselModel> AddAsync(AkselModel model)
        {
            await _modelValidator.ValidateAsync(model);
            
            AkselEntity entity = _mapper.Map<AkselEntity>(model);
            AkselEntity AkselEntity = await _AkselRepository.AddAsync(entity);
            AkselModel AkselModel = _mapper.Map<AkselModel>(AkselEntity);

            return AkselModel;
        }

        public async Task DeleteAsync(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            AkselEntity AkselEntity = await _AkselRepository.GetAsync(id);

            if (AkselEntity == null)
            {
                throw new Exception();
            }

            AkselEntity.IsActive = false;

            await _AkselRepository.UpdateAsync(AkselEntity);
        }

        public async Task UpdateAsync(AkselModel model)
        {
            await _modelValidator.ValidateAsync(model);
            
            AkselEntity entity = _mapper.Map<AkselEntity>(model);
            
            await _AkselRepository.UpdateAsync(entity);
        }

        public async Task<AkselModel> GetAsync(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            AkselEntity AkselEntity = await _AkselRepository.GetAsync(id);
            AkselModel AkselModel = _mapper.Map<AkselModel>(AkselEntity);

            return AkselModel;
        }
    }
}