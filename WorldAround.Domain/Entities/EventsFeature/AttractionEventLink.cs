namespace WorldAround.Domain.Entities;

public class AttractionEventLink
{
    public int AttractionId { get; set; }
    public int EventId { get; set; }

    public Attraction Attraction { get; set; }
    public Event Event { get; set; }
}
