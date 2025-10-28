using Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Vue.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    [Authorize] // Yêu cầu phải đăng nhập
    public class ImagesController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public ImagesController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost("upload")] // URL: /api/admin/images/upload
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Mở file như một Stream
            await using var stream = file.OpenReadStream();

            // Gọi service (Application)
            var result = await _photoService.UploadPhotoAsync(stream, file.FileName, true);

            return Ok(new { url = result.Url, publicId = result.PublicId });
        }
    }
}