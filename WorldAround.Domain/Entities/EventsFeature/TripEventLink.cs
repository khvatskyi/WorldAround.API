namespace WorldAround.Domain.Entities;

public class TripEventLink
{
    public int TripId { get; set; }
    public int EventId { get; set; }

    public Trip Trip { get; set; }
    public Event Event { get; set; }
}
