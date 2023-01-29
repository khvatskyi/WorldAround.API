using WorldAround.Domain.Enums;
using WorldAround.Domain.Models.Base;

namespace WorldAround.Domain.Models.Events;

public class GetEventsParams : GetDataParams
{
    public int? UserId { get; set; }

    public bool? IsOwner { get; set; }

    public AccessibilityProfile? Accessibility { get; set; }
}
