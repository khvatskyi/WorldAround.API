namespace WorldAround.Domain.Models.Trips;

public class GetTripsParams
{
    public int? UserId { get; set; }

    public string SearchValue { get; set; }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public bool IncludePins { get; set; }
}