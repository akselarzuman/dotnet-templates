using Armut.Models.Models;
using Armut.Models.ViewModels;
using Armut.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Armut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmutController : ControllerBase
    {
        private readonly IArmutService _armutService;

        public ArmutController(IArmutService armutService)
        {
            _armutService = armutService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ArmutModel armutModel = _armutService.Get();
            ArmutViewModel armutViewModel = Mapper.Map<ArmutViewModel>(armutModel);

            return Ok();
        }
    }
}