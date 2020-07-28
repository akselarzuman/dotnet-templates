using System;
using System.Linq;
using System.Threading.Tasks;
using Aksel.Models.Models;
using Aksel.ModelValidators;
using Aksel.ModelValidators.FluentValidator;
using Aksel.Repository.Contracts;
using Aksel.Repository.Entities;
using Aksel.Service.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Aksel.Service
{
    public class AkselService : IAkselService
    {
        private readonly IAkselRepository _AkselRepository;
        private readonly IModelValidator _modelValidator;
        private readonly IMapper _mapper;

        public AkselService(IAkselRepository AkselRepository,
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
            EntityEntry<AkselEntity> AkselEntity = await _AkselRepository.AddAsync(entity);
            await _AkselRepository.SaveChangesAsync();

            AkselModel AkselModel = _mapper.Map<AkselModel>(AkselEntity.Entity);

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

            _AkselRepository.Update(AkselEntity);
            await _AkselRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(AkselModel model)
        {
            await _modelValidator.ValidateAsync(model);
            
            AkselEntity entity = _mapper.Map<AkselEntity>(model);
            
            _AkselRepository.Update(entity);
            await _AkselRepository.SaveChangesAsync();
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