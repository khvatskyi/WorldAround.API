using WorldAround.Domain.Entities.Base;

namespace WorldAround.Domain.Entities;

public class Attraction : Point
{
    public int Id { get; set; }
    public int? AuthorId { get; set; }

    public User Author { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Rating> Ratings { get; set; }
    public List<Pin> Pins { get; set; }
    public List<Image> Images { get; set; }
    public List<AttractionEventLink> AttractionEventLinks { get; set; }
}
