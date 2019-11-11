using System.Threading.Tasks;
using Aksel.Models.ViewModels.Authorization;
using Aksel.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aksel.Auth.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthorizationController(ILoginService AkselService)
        {
            _loginService = AkselService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            string token = await _loginService.LoginAsync(model.Email, model.Password);

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }

            return Ok(token);
        }
    }
}