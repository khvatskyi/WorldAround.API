using WorldAround.Domain.Entities.Base;

namespace WorldAround.Domain.Entities;

public class Pin : Point
{
    public int Id { get; set; }

    public int TripId { get; set; }
    public int SequenceNumber { get; set; }
    public int? AttractionId { get; set; }

    public Trip Trip { get; set; }
    public Attraction Attraction { get; set; }
    public List<Image> Images { get; set; }
}
