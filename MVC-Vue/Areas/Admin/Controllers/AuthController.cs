using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVC_Vue.Areas.Admin.Models;
using MVC_Vue.Databases;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVC_Vue.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("login")] // URL sẽ là: /api/admin/auth/login
        public IActionResult Login([FromBody] LoginRequest login)
        {
            // --- BƯỚC XÁC THỰC ---
            // Đây là nơi bạn kiểm tra DB.
            User? user = UserDatabase.LoginUser(login.Email, login.Password);
            if (user != null)
            {
                // Nếu đúng, tạo token
                var token = GenerateJwtToken(user);
                return Ok(new { token = token });
            }

            // Nếu sai, trả về lỗi
            return Unauthorized(new { message = "Email hoặc mật khẩu không đúng." });
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tạo các "claims" (thông tin bên trong token)
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // ID duy nhất cho mỗi token
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2), // Thời gian sống của token
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
