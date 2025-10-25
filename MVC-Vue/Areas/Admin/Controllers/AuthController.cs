using Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC_Vue.Areas.Admin.Models;

namespace MVC_Vue.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")] // URL: /api/admin/auth/login
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _authService.LoginAsync(new Core.Application.DTOs.LoginDto
            {
                Username = login.Email,
                Password = login.Password
            });

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { token = token });
            }

            // Unauthorized
            return Unauthorized(new { message = "Email hoặc mật khẩu không đúng." });
        }
    }
}
