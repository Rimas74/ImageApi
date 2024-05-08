using ImageApi.Models;

namespace ImageApi.Services.Interfaces
{
    public interface IImageService
    {
        Task<Image> UploadImageAsync(Image image);
        //Task<Thumbnail> AddThumbnailAsync(Thumbnail thumbnail);
        Task<Thumbnail> GetThumbnailAsync(int id);
        Task<Image> GetImageAsync(int id);
    }
}
