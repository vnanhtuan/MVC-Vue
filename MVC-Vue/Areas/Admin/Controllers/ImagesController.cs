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
        private readonly IWebHostEnvironment _env;

        // Tiêm IWebHostEnvironment để lấy đường dẫn wwwroot
        public ImagesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("upload")] // URL: /api/admin/images/upload
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Không có file nào được tải lên.");
            }

            // 1. TẠO THƯ MỤC "TEMP" NẾU CHƯA CÓ
            // Đường dẫn vật lý: .../wwwroot/uploads/temp
            var tempDir = Path.Combine(_env.WebRootPath, "uploads", "temp");
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            // 2. TẠO TÊN FILE DUY NHẤT
            var fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(tempDir, uniqueFileName);

            // 3. LƯU FILE VÀO THƯ MỤC "TEMP"
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // 4. TRẢ VỀ URL CÓ THỂ TRUY CẬP CÔNG KHAI
            // URL: /uploads/temp/ten_file_duy_nhat.jpg
            var publicUrl = $"/uploads/temp/{uniqueFileName}";
            
            return Ok(new { url = publicUrl });
        }
    }
}