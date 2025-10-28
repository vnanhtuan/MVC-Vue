using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
