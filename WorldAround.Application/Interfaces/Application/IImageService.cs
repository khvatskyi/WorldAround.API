using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Images;

namespace WorldAround.Application.Interfaces.Application;

public interface IImageService
{
    Task<ImageModel> Get(int id);

    Task<ImageModel> Create(Image image);

    Task Delete(int id);
}
