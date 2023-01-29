using WorldAround.Domain.Enums;

namespace WorldAround.Domain.Models.Events;

public class UpdateEventModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public AccessibilityProfile? Accessibility { get; set; }

    public List<int> TripIds { get; set; }
    public List<int> ParticipantIds { get; set; }
}
