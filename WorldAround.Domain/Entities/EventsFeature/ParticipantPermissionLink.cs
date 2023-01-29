namespace WorldAround.Domain.Entities;

public class ParticipantPermissionLink
{
    public int ParticipantId { get; set; }
    public int PermissionId { get; set; }

    public Participant Participant { get; set; }
    public ParticipantPermission Permission { get; set; }
}
