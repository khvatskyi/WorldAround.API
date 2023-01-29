namespace WorldAround.Domain.Models.Trips;

public class CreateTripModel
{
    public int? AuthorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<PinModel> Pins { get; set; }
}