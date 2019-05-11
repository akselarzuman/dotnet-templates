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

        public AkselController(IAkselService AkselService)
        {
            _AkselService = AkselService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            AkselModel AkselModel = await _AkselService.GetAsync();
            AkselViewModel AkselViewModel = Mapper.Map<AkselViewModel>(AkselModel);

            return Ok(AkselViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AkselViewModel AkselViewModel)
        {
            AkselModel AkselModel = Mapper.Map<AkselModel>(AkselViewModel);
            AkselModel model = await _AkselService.AddAsync(AkselModel);
            AkselViewModel AkselVm = Mapper.Map<AkselViewModel>(model);

            return Created("", AkselVm);
        }
    }
}