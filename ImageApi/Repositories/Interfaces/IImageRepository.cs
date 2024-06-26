﻿using ImageApi.Models;

namespace ImageApi.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> AddImageAsync(Image image);
        Task<Thumbnail> AddThumbnailAsync(Thumbnail thumbnail);
        Task<Image> GetImageByIdAsync(int id);
        Task<Thumbnail> GetThumbnailByIdAsync(int id);
    }
}
