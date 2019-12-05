using System.Threading.Tasks;
using Aksel.Models.Models;
using Aksel.Models.ViewModels;
using Aksel.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aksel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AkselController : ControllerBase
    {
        private readonly IAkselService _AkselService;
        private readonly IMapper _mapper;

        public AkselController(IAkselService AkselService,
            IMapper mapper)
        {
            _AkselService = AkselService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            AkselModel AkselModel = await _AkselService.GetAsync(id);
            AkselViewModel AkselViewModel = _mapper.Map<AkselViewModel>(AkselModel);

            return Ok(AkselViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AkselViewModel AkselViewModel)
        {
            AkselModel AkselModel = _mapper.Map<AkselModel>(AkselViewModel);
            AkselModel model = await _AkselService.AddAsync(AkselModel);
            AkselViewModel AkselVm = _mapper.Map<AkselViewModel>(model);

            return Created("", AkselVm);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            await _AkselService.DeleteAsync(id);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Update(AkselViewModel AkselViewModel)
        {
            AkselModel AkselModel = _mapper.Map<AkselModel>(AkselViewModel);
            await _AkselService.UpdateAsync(AkselModel);

            return Ok();
        }
    }
}