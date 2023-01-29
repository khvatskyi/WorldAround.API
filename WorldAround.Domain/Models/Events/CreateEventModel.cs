using Microsoft.AspNetCore.Http;
using WorldAround.Domain.Enums;

namespace WorldAround.Domain.Models.Events;

public class CreateEventModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public AccessibilityProfile Accessibility { get; set; }
    public int CreateUserId { get; set; }
    public IFormFile Image { get; set; }

    public List<PlaceItem> Places { get; set; }
    public List<int> Participants { get; set; }
}
