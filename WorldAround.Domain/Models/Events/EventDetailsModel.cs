using WorldAround.Domain.Models.Trips;
using WorldAround.Domain.Models.Users;

namespace WorldAround.Domain.Models.Events;

public class EventDetailsModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public List<PlaceItem> Places { get; set; }
    public List<ParticipantModel> Participants { get; set; }
}
