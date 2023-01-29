namespace WorldAround.Domain.Models.Attractions;

public class GetAttractionsModel
{
    public IReadOnlyCollection<AttractionModel> Data { get; set; }
    public int Length { get; set; }
}