namespace WorldAround.Domain.Entities;

public class Trip
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? AuthorId { get; set; }
    public DateTime CreateDate { get; set; }

    public User Author { get; set; }
    public List<Pin> Pins { get; set; }
    public List<TripEventLink> TripEventLinks { get; set; }
    public List<Rating> Ratings { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Image> Images { get; set; }
    public List<Album> Albums { get; set; }
}
