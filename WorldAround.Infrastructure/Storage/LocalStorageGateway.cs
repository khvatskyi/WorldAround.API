using Microsoft.AspNetCore.Http;
using WorldAround.Application.Interfaces.Infrastructure;

namespace WorldAround.Infrastructure.Storage;

public class LocalStorageGateway : IBlobStorageGateway
{
    private readonly string _imagesStoragePath = Environment.GetEnvironmentVariable("WA_LOCAL_STORAGE") + "\\storage-images";

    public async Task UploadImageAsync(string fileName, IFormFile file)
    {
        var filePath = Path.Combine(_imagesStoragePath, fileName);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);
    }

    public Task DeleteImageAsync(string blobName)
    {
        var filePath = Path.Combine(_imagesStoragePath, blobName);
        File.Delete(filePath);

        return Task.CompletedTask;
    }

    public async Task DeleteImagesAsync(string[] blobNames)
    {
        foreach (var blobName in blobNames)
        {
            await DeleteImageAsync(blobName);
        }
    }
}
