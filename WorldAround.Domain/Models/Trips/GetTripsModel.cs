namespace WorldAround.Domain.Models.Trips;

public class GetTripsModel
{
    public IReadOnlyCollection<TripModel> Data { get; set; }
    public int Length { get; set; }
}