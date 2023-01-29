using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using WorldAround.Application.Interfaces.Infrastructure;

namespace WorldAround.Infrastructure.Storage;

public class BlobStorageGateway : IBlobStorageGateway
{
    private const string ImageContainer = "images";

    private readonly BlobServiceClient _blobServiceClient;

    public BlobStorageGateway(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task UploadImageAsync(string blobName, IFormFile file)
    {
        var blobClient = GetImageBlobClient(blobName);

        var fileStream = file.OpenReadStream();

        await blobClient.UploadAsync(fileStream, true);
    }

    public async Task DeleteImageAsync(string blobName)
    {
        var blobClient = GetImageBlobClient(blobName);

        await blobClient.DeleteIfExistsAsync();
    }

    public async Task DeleteImagesAsync(string[] blobNames)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(ImageContainer);

        var deleteTasks = blobNames
            .Select(x => containerClient.GetBlobClient(x).DeleteIfExistsAsync());

        await Task.WhenAll(deleteTasks);
    }

    private BlobClient GetImageBlobClient(string blobName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(ImageContainer);
        return containerClient.GetBlobClient(blobName);
    }
}
