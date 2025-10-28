namespace Core.Application.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoUploadResult> UploadPhotoAsync(Stream fileStream, string fileName, bool isTemp = false);
        Task DeletePhotoAsync(string publicId);
    }

    // DTO trả về kết quả sau khi upload
    public class PhotoUploadResult
    {
        public string PublicId { get; set; }
        public string Url { get; set; }
    }
}
