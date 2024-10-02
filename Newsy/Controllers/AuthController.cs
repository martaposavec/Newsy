using Newsy.Services.Interfaces;
using Newsy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Newsy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            var token = _authService.Authenticate(login.Username, login.Password);

            if (token == null) return Unauthorized();

            return Ok(new { Token = token });
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignupViewModel model)
        {
            _authService.Signup(model);
            return Ok();
        }
    }
}

