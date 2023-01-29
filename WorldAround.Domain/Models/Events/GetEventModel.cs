using WorldAround.Domain.Models.Users;

namespace WorldAround.Domain.Models.Events;

public class GetEventModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ImagePath { get; set; }

    public UserModel Author { get; set; }
}
