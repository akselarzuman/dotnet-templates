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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModelValidator _modelValidator;
        private readonly IMapper _mapper;

        public AkselService(
            IAkselRepository AkselRepository,
            IUnitOfWork unitOfWork,
            IModelValidator modelValidator,
            IMapper mapper)
        {
            _AkselRepository = AkselRepository;
            _unitOfWork = unitOfWork;
            _modelValidator = modelValidator;
            _mapper = mapper;
        }

        public async Task<AkselModel> AddAsync(AkselModel model)
        {
            await _modelValidator.ValidateAsync(model);
            
            AkselEntity entity = _mapper.Map<AkselEntity>(model);
            AkselEntity AkselEntity = await _AkselRepository.AddAsync(entity);
            AkselModel AkselModel = _mapper.Map<AkselModel>(AkselEntity);

            await _unitOfWork.SaveChangesAsync();

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
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(AkselModel model)
        {
            await _modelValidator.ValidateAsync(model);
            
            AkselEntity entity = _mapper.Map<AkselEntity>(model);
            
            await _AkselRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
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