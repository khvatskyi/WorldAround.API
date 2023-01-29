namespace WorldAround.Domain.Entities;

public class Image
{
    public int Id { get; set; }
    public string ImagePath { get; set; }

    public int? EventId { get; set; }
    public int? TripId { get; set; }
    public int? AttractionId { get; set; }
    public int? PinId { get; set; }
    public int? AlbumId { get; set; }

    public Event Event { get; set; }
    public Trip Trip { get; set; }
    public Attraction Attraction { get; set; }
    public Pin Pin { get; set; }
    public Album Album { get; set; }
    public List<User> Users { get; set; }
}
