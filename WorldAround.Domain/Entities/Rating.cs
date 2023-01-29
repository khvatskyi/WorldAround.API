namespace WorldAround.Domain.Entities;

public class Rating
{
    public int Id { get; set; }
    public int? AuthorId { get; set; }
    public int Value { get; set; }

    public int? TripId { get; set; }
    public int? EventId { get; set; }
    public int? AttractionId { get; set; }
    public int? UserId { get; set; }

    public User Author { get; set; }
    public Trip Trip { get; set; }
    public Event Event { get; set; }
    public Attraction Attraction { get; set; }
    public User User { get; set; }
}
