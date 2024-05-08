using ImageApi.Models;
using ImageApi.Repositories;
using ImageApi.Repositories.Interfaces;
using ImageApi.Services.Interfaces;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace ImageApi.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Models.Image> GetImageAsync(int id) => await _imageRepository.GetImageByIdAsync(id);

        public async Task<Thumbnail> GetThumbnailAsync(int id) => await _imageRepository.GetThumbnailByIdAsync(id);

        public async Task<Models.Image> UploadImageAsync(Models.Image image)
        {
            var savedImage = await _imageRepository.AddImageAsync(image);

            var thumbnailData = CreateThumbnail(image.Data, 100, 100);
            var thumbnail = new Thumbnail
            {
                ImageId = savedImage.Id,
                Image = savedImage,
                FileName = $"thumb_{savedImage.FileName}",
                Data = thumbnailData
            };

            await _imageRepository.AddThumbnailAsync(thumbnail);
            return savedImage;
        }


        private byte[] CreateThumbnail(byte[] imageData, int width, int height)
        {
            using var ms = new MemoryStream(imageData);
            using var img = System.Drawing.Image.FromStream(ms);

            using var thumb = img.GetThumbnailImage(width, height, null, IntPtr.Zero);

            using var thumbStream = new MemoryStream();
            thumb.Save(thumbStream, ImageFormat.Jpeg);

            return thumbStream.ToArray();
        }


    }
}
