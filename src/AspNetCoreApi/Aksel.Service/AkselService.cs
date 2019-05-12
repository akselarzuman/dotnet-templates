using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Aksel.Models.Entities;
using Aksel.Models.Models;
using Aksel.ModelValidators;
using Aksel.Repository.Contracts;
using Aksel.Service.Contracts;
using AutoMapper;
using ValidationResult = FluentValidation.Results.ValidationResult;

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
            await ValidateAsync(model);
            
            AkselEntity entity = Mapper.Map<AkselEntity>(model);
            AkselEntity AkselEntity = await _AkselRepository.AddAsync(entity);
            AkselModel AkselModel = Mapper.Map<AkselModel>(AkselEntity);

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
            await ValidateAsync(model);
            
            AkselEntity entity = Mapper.Map<AkselEntity>(model);
            
            await _AkselRepository.UpdateAsync(entity);
        }

        public async Task<AkselModel> GetAsync(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            AkselEntity AkselEntity = await _AkselRepository.GetAsync(id);
            AkselModel AkselModel = Mapper.Map<AkselModel>(AkselEntity);

            return AkselModel;
        }

        private async Task ValidateAsync(AkselModel model)
        {
            var validator = new AkselModelValidator();
            ValidationResult validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                string errorMessage = validationResult.Errors?.First()?.ErrorMessage;
                
                throw new Exception(errorMessage);
            }
        }
    }
}