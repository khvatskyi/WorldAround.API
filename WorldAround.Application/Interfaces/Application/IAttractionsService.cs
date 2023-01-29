using WorldAround.Domain.Models.Attractions;

namespace WorldAround.Application.Interfaces.Application;

public interface IAttractionsService
{
    Task<GetAttractionModel> GetAttractionAsync(int attractionId, CancellationToken cancellationToken);

    Task<GetAttractionsModel> GetAttractionsAsync(GetAttractionsParams @params, CancellationToken cancellationToken);

    Task CreateAttractionAsync(CreateAttractionModel createAttractionModel);
}