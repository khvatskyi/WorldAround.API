namespace WorldAround.Domain.Models.Attractions;

public class GetAttractionsParams
{
    public int? UserId { get; set; }

    public string SearchValue { get; set; }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}