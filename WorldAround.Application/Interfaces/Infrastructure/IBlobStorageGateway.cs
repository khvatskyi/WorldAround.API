using Microsoft.AspNetCore.Http;

namespace WorldAround.Application.Interfaces.Infrastructure;

public interface IBlobStorageGateway
{
    Task UploadImageAsync(string fileName, IFormFile file);
    Task DeleteImageAsync(string blobName);
    Task DeleteImagesAsync(string[] blobNames);
}