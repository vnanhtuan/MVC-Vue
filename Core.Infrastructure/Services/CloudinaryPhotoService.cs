using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Core.Infrastructure.Services
{
    public class CloudinaryPhotoService: IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryPhotoService(IConfiguration configuration)
        {
            // Lấy thông tin từ appsettings.json
            var account = new Account(
                configuration["CloudinarySettings:CloudName"],
                configuration["CloudinarySettings:ApiKey"],
                configuration["CloudinarySettings:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<PhotoUploadResult> UploadPhotoAsync(Stream fileStream, string fileName, bool isTemp = false)
        {
            // Tạo các tham số upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, fileStream),
                // (Tùy chọn) Thêm logic biến đổi, thư mục, v.v.
                 Folder = isTemp ? "temps" : "products" 
            };

            // Thực hiện upload
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new System.Exception(uploadResult.Error.Message);
            }

            // Trả về kết quả
            return new PhotoUploadResult
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.SecureUrl.ToString() // Dùng SecureUrl (https)
            };
        }

        public async Task DeletePhotoAsync(string publicId)
        {
            if (string.IsNullOrEmpty(publicId))
                return; // Không có gì để xóa

            var deletionParams = new DeletionParams(publicId)
            {
                ResourceType = ResourceType.Image
            };

            var result = await _cloudinary.DestroyAsync(deletionParams);

            if (result.Result != "ok" && result.Error != null)
            {
                // Nếu muốn xử lý lỗi nghiêm ngặt, bạn có thể ném ra exception
                throw new System.Exception($"Lỗi khi xóa ảnh khỏi Cloudinary: {result.Error.Message}");
            }
            // Nếu không, chúng ta có thể bỏ qua (lỗi sẽ được ghi log trên Cloudinary)
        }
    }
}
