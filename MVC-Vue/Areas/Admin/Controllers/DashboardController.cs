using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MVC_Vue.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDashboard()
        {
            // 3. Code này sẽ CHỈ CHẠY nếu request
            // có chứa JWT hợp lệ trong header Authorization

            // Lấy email của user từ token (nếu cần)
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;

            // JwtRegisteredClaimNames để lấy ra
            var name = User.FindFirst(JwtRegisteredClaimNames.Name)?.Value;

            return Ok(new
            {
                message = $"Chào mừng {name}!",
                totalOrders = 150
            });
        }
    }
}
