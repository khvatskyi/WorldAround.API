using Microsoft.AspNetCore.Identity;

namespace WorldAround.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool? IsActive { get; set; }
    public int? ImageId { get; set; }

    public Image Image { get; set; }
    public List<Comment> CreatedComments { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Rating> CreatedRatings { get; set; }
    public List<Rating> Ratings { get; set; }
    public List<Trip> CreatedTrips { get; set; }
    public List<Participant> Participants { get; set; }
    public List<Attraction> CreatedAttractions { get; set; }
}
